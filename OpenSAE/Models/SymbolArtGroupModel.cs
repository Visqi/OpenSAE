﻿using OpenSAE.Core;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace OpenSAE.Models
{
    public class SymbolArtGroupModel : SymbolArtItemModel
    {
        protected string? _name;
        protected bool _visible;

        public SymbolArtGroupModel(ISymbolArtGroup group, SymbolArtItemModel? parent)
            : this()
        {
            Parent = parent;
            _name = group.Name;
            _visible = group.Visible;

            foreach (var item in group.Children)
            {
                if (item is ISymbolArtGroup subGroup)
                {
                    Children.Add(new SymbolArtGroupModel(subGroup, this));
                }
                else if (item is SymbolArtLayer layer)
                {
                    Children.Add(new SymbolArtLayerModel(layer, this));
                }
                else
                {
                    throw new Exception($"Item of unknown type {item.GetType().Name} found in symbol art group");
                }
            }
        }

        public SymbolArtGroupModel(string name, SymbolArtItemModel parent)
            : this()
        {
            _name = name;
            _visible = true;
            Parent = parent;
        }

        protected SymbolArtGroupModel()
            : base()
        {
        }

        public override string? Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public override bool Visible
        {
            get => _visible;
            set => SetProperty(ref _visible, value);
        }

        /// <summary>
        /// Only exists to prevent databinding error - is always null
        /// </summary>
        public Symbol? Symbol
        {
            get => null;
            set { }
        }

        public override bool IsVisible => Parent!.IsVisible && Visible;

        public override Point[] Vertices
        {
            get
            {
                var layers = GetAllLayers().ToArray();

                // we'll just assume the 4 points are the 4 extreme points of any in the group/subgroups
                var allPoints = layers.SelectMany(x => x.Vertices).ToArray();

                if (allPoints.Length == 0)
                {
                    var none = new Point(0, 0);
                    
                    return new Point[]
                    {
                        none, none, none, none
                    };
                }

                double minX = allPoints.MinBy(x => x.X).X, maxX = allPoints.MaxBy(x => x.X).X;
                double minY = allPoints.MinBy(x => x.Y).Y, maxY = allPoints.MaxBy(x => x.Y).Y;

                return new[]
                {
                    new Point(minX, minY),
                    new Point(minX, maxY),
                    new Point(maxX, minY),
                    new Point(maxX, maxY)
                };
            }
            set
            {
            }
        }

        public Point[] AbsoluteVertices
        {
            get
            {
                var layers = GetAllLayers().ToArray();

                // we'll just assume the 4 points are the 4 extreme points of any in the group/subgroups
                var allPoints = layers.SelectMany(x => x.Vertices).ToArray();

                if (allPoints.Length == 0)
                {
                    var none = new Point(0, 0);

                    return new Point[]
                    {
                        none, none, none, none
                    };
                }

                return new[]
                {
                    allPoints.OrderBy(x => x.X).First(),
                    allPoints.OrderByDescending(x => x.Y).First(),
                    allPoints.OrderBy(x => x.Y).First(),
                    allPoints.OrderByDescending(x => x.X).First(),

                };
            }
        }

        /// <summary>
        /// Gets or sets the position of the entire symbol. The origin of the position
        /// is the leftmost vertex
        /// </summary>
        public override Point Position
        {
            get => Vertices.GetMinBy(true);
            set
            {
                var points = Vertices;

                int minIndex = points.GetMinIndexBy(true);

                // find diff between previous min point and the new one
                var diff = value - points[minIndex];

                var layers = GetAllLayers().ToArray();

                // update all points for all layers beneath this group
                foreach (var layer in layers)
                {
                    layer.Position += diff;
                }

                OnPropertyChanged();
                OnPropertyChanged(nameof(Vertices));
            }
        }

        public override double Alpha
        {
            get
            {
                var layers = GetAllLayers().ToArray();

                return layers.Length > 0 ? layers.Average(x => x.Alpha) : 1;
            }
            set
            {
                foreach (var layer in GetAllLayers())
                {
                    layer.Alpha = value;
                }

                OnPropertyChanged();
            }
        }

        public override Color Color
        {
            get => GetAllLayers().FirstOrDefault()?.Color ?? new Color();
            set
            {
                foreach (var layer in GetAllLayers())
                {
                    layer.Color = value;
                }

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Groups always show bounding vertices
        /// </summary>
        public override bool ShowBoundingVertices
        {
            get => true;
            set
            {
            }
        }

        public override SymbolArtItemModel Duplicate(SymbolArtItemModel parent)
        {
            var duplicateGroup = new SymbolArtGroupModel()
            {
                Name = Name,
                Visible = Visible,
                Parent = parent
            };

            // this will be recursive since child groups will also be duplicated
            foreach (var child in Children)
            {
                duplicateGroup.Children.Add(child.Duplicate(duplicateGroup));
            }

            return duplicateGroup;
        }

        public override SymbolArtItem ToSymbolArtItem()
        {
            return new SymbolArtGroup()
            {
                Name = _name,
                Visible = _visible,
                Children = Children.Select(x => x.ToSymbolArtItem()).ToList()
            };
        }

        public override void FlipX()
        {
            // find center origin
            var originX = Vertices.GetCenterX();

            foreach (var layer in GetAllLayers())
            {
                layer.Vertices = SymbolManipulationHelper.FlipX(layer.Vertices, originX);
            }
        }

        public override void FlipY()
        {
            // find center origin
            var originY = Vertices.GetCenterY();

            foreach (var layer in GetAllLayers())
            {
                layer.Vertices = SymbolManipulationHelper.FlipY(layer.Vertices, originY);
            }
        }

        public override void Rotate(double angle)
        {
            // find center origin
            var origin = Vertices.GetCenter();

            foreach (var layer in GetAllLayers())
            {
                layer.Vertices = SymbolManipulationHelper.Rotate(layer.Vertices, origin, angle);
            }

            OnPropertyChanged(nameof(Vertices));
            OnPropertyChanged(nameof(Position));
        }

        public override void TemporaryRotate(double angle)
        {
            StartManipulation();

            var origin = _temporaryVertices.GetCenter();

            foreach (var layer in GetAllLayers())
            {
                layer.TemporaryRotate(angle, origin);
            }

            OnPropertyChanged(nameof(Vertices));
            OnPropertyChanged(nameof(Position));
        }

        public override void CommitManipulation()
        {
            foreach (var layer in GetAllLayers())
            {
                layer.CommitManipulation();
            }

            base.CommitManipulation();
        }

        /// <summary>
        /// Sets the specified vertex to a new position, shifting all vertices in all layers in the group
        /// accordingly, effectively resizing the group as a whole.
        /// </summary>
        /// <param name="vertexIndex">Index of vertex to change position for. (0-3)</param>
        /// <param name="point">New location for the vertex</param>
        /// <exception cref="ArgumentException"></exception>
        public override void ResizeFromVertex(int vertexIndex, Point point)
        {
            StartManipulation();

            // find the origin and opposite vertex - this is necessary
            // in order to calculate the vector for each vertex of each layer
            // in this group
            var originVertex = Vertices[vertexIndex];
            var oppositeVertex = Vertices[vertexIndex switch
            {
                0 => 3,
                1 => 2,
                2 => 1,
                3 => 0,
                _ => throw new ArgumentException("Vertex must be in the range 0-3")
            }];

            Vector vector = point - originVertex;

            // get the bounds of the group
            var width = Math.Max(originVertex.X, oppositeVertex.X) - Math.Min(originVertex.X, oppositeVertex.X);
            var height = Math.Max(originVertex.Y, oppositeVertex.Y) - Math.Min(originVertex.Y, oppositeVertex.Y);

            // ensure it is not possible to resize the group below 1x1 by clearing the 
            // x and or y axis of the vector according to the direction being resized
            var absVectorX = vertexIndex == 0 || vertexIndex == 1 ? vector.X : -vector.X;
            var absVectorY = vertexIndex == 0 || vertexIndex == 2 ? vector.Y : -vector.Y;

            if (width - absVectorX < 1)
                vector.X = 0;

            if (height - absVectorY < 1)
                vector.Y = 0;

            if (vector.Length == 0)
                return;

            foreach (var layer in GetAllLayers())
            {
                for (int i = 0; i < 4; i++)
                {
                    // for each vertex for the layer, calculate
                    var targetVertex = layer.Vertices[i];

                    // find the distance from the x and y origins of the group for the vertex
                    var distanceFromOriginX = Math.Max(originVertex.X, targetVertex.X) - Math.Min(originVertex.X, targetVertex.X);
                    var distanceFromOriginY = Math.Max(originVertex.Y, targetVertex.Y) - Math.Min(originVertex.Y, targetVertex.Y);

                    // and reduce the vector to add accordingly
                    var xScale = 1 - distanceFromOriginX / width;
                    var yScale = 1 - distanceFromOriginY / height;

                    // Explanation:
                    // Imagine that this vertex is at the absolute corner of the group (the coordinates are identical)
                    // This means that it should be moved exactly to the point specified as an argument to this function,
                    // thus the xScale and yScale are both 1.
                    //
                    // For another vertex in the group at _any other location_, it will need to be moved less in order to
                    // properly resize the group. Unless the distance to this vertex from the origin vertex is identical
                    // for X and Y, the scale factor will be different for X and Y.
                    //
                    // Imagine a vertex right in the center of the group. This vertex will have both an X and Y scale
                    // of 0.5. So it will move half as much as our imagined vertex at the corner as described above.

                    layer.SetVertex(i, targetVertex + new Vector(vector.X * xScale, vector.Y * yScale));
                }
            }

            OnPropertyChanged();
            OnPropertyChanged(nameof(Position));
            OnPropertyChanged(nameof(Vertices));
        }

        /// <summary>
        /// Moves the specified (virtual) vertex to the specified point, shifting all points in the group
        /// and transforming the shape of the group.
        /// </summary>
        /// <param name="vertexIndex">Index of vertex to change position for. (0-3)</param>
        /// <param name="point">New location for the vertex</param>
        /// <exception cref="ArgumentException"></exception>
        public override void SetVertex(int vertexIndex, Point point)
        {
            StartManipulation();

            // find the origin and opposite vertex - this is necessary
            // in order to calculate the vector for each vertex of each layer
            // in this group
            var originVertex = _temporaryVertices[vertexIndex];
            var oppositeVertex = _temporaryVertices[vertexIndex switch
            {
                0 => 3,
                1 => 2,
                2 => 1,
                3 => 0,
                _ => throw new ArgumentException("Vertex must be in the range 0-3")
            }];

            Vector vector = point - originVertex;

            if (vector.Length == 0)
            {
                return;
            }

            var diff = (originVertex - oppositeVertex).Length;

            foreach (var layer in GetAllLayers())
            {
                for (int i = 0; i < 4; i++)
                {
                    // for each vertex for the layer, calculate
                    var targetVertex = layer.OriginalVertices[i];

                    // find the distance from the x and y origins of the group for the vertex
                    var distanceFromOrigin = (originVertex - targetVertex).Length;

                    // and reduce the vector to add accordingly
                    var scale = 1 - distanceFromOrigin / diff * 1.2;

                    // Explanation:
                    // Imagine that this vertex is at the absolute corner of the group (the coordinates are identical)
                    // This means that it should be moved exactly to the point specified as an argument to this function,
                    // thus the xScale and yScale are both 1.
                    //
                    // For another vertex in the group at _any other location_, it will need to be moved less in order to
                    // properly resize the group. Unless the distance to this vertex from the origin vertex is identical
                    // for X and Y, the scale factor will be different for X and Y.
                    //
                    // Imagine a vertex right in the center of the group. This vertex will have both an X and Y scale
                    // of 0.5. So it will move half as much as our imagined vertex at the corner as described above.
                    layer.SetVertex(i, targetVertex + new Vector(vector.X * scale, vector.Y * scale));
                }
            }

            OnPropertyChanged();
            OnPropertyChanged(nameof(Position));
            OnPropertyChanged(nameof(Vertices));
        }
    }
}
