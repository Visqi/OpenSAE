﻿using SixLabors.ImageSharp.PixelFormats;

namespace OpenSAE.Core.BitmapConverter
{
    internal static class GeometrizeUtil
    {
        public static int ColorToInt(Rgba32 color)
            => (color.R << 24) + (color.G << 16) + (color.B << 8) + color.A;

        public static Rgba32 IntToColor(int color)
            => new((byte)((color >> 24) & 255), (byte)((color >> 16) & 255), (byte)((color >> 8) & 255), (byte)(color & 255));

        public static System.Windows.Media.Color ToWindowsMediaColor(Rgba32 color)
            => System.Windows.Media.Color.FromRgb(color.R, color.G, color.B);

        public static GeometrizeShape ConvertShape(object source)
        {
            var ishape = ((geometrize.shape.Shape)haxe.lang.Runtime.getField(source, "shape", 2082267937, true));

            HaxeArray<double> data = ishape.getRawShapeData();

            var points = new double[data.length];

            for (int i = 0; i < data.length; i++)
                points[i] = data[i];

            var type = (ShapeType)ishape.getType();
            var color = IntToColor((int)(haxe.lang.Runtime.getField_f(source, "color", 1247572323, true)));
            var score = haxe.lang.Runtime.getField_f(source, "score", 2027516754, true);

            return new GeometrizeShape(type, color, score, points);
        }
    }
}
