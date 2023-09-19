// Generated by Haxe 4.3.1

#pragma warning disable 109, 114, 219, 429, 168, 162
using Geometrize.Rasterizer;
using System;
using System.Collections.Generic;

namespace Geometrize.Shape
{
    public class Ellipse : IShape
    {

        public Ellipse()
        {
        }


        public Ellipse(int xBound, int yBound)
        {
            x = global::Std.random(xBound);
            y = global::Std.random(yBound);
            rx = global::Std.random(32) + 1;
            ry = global::Std.random(32) + 1;
            this.xBound = xBound;
            this.yBound = yBound;
        }

        public int x;

        public int y;

        public int rx;

        public int ry;

        public int xBound;

        public int yBound;

        public virtual IReadOnlyList<Scanline> Rasterize()
        {
            var lines = new List<Scanline>();

            double aspect = ((double)this.rx) / this.ry;
            int w = this.xBound;
            int h = this.yBound;

            for (int dy = 0; dy < ry; dy++)
            {
                int y1 = this.y - dy;
                int y2 = this.y + dy;
                if (((y1 < 0) || (y1 >= h)) && ((y2 < 0) || (y2 >= h)))
                {
                    continue;
                }

                int s = (int)(System.Math.Sqrt((this.ry * this.ry) - (dy * dy)) * aspect);
                int x1 = this.x - s;
                int x2 = this.x + s;
                if (x1 < 0)
                {
                    x1 = 0;
                }

                if (x2 >= w)
                {
                    x2 = w - 1;
                }

                if ((y1 >= 0) && (y1 < h))
                {
                    lines.Add(new Scanline(y1, x1, x2));
                }

                if ((y2 >= 0) && (y2 < h) && (dy > 0))
                {
                    lines.Add(new Scanline(y2, x1, x2));
                }
            }

            return lines;
        }


        public virtual void Mutate()
        {
            unchecked
            {
                int r = global::Std.random(3);
                switch (r)
                {
                    case 0:
                        {
                            int @value = this.x + -16 + ((int)global::System.Math.Floor((double)(33 * global::HaxeMath.rand.NextDouble())));
                            int max = this.xBound - 1;
                            if (0 > max)
                            {
                                throw new Exception("FAIL: min <= max");
                            }

                            this.x = (@value < 0) ? 0 : ((@value > max) ? max : @value);
                            int value1 = this.y + -16 + ((int)global::System.Math.Floor((double)(33 * global::HaxeMath.rand.NextDouble())));
                            int max1 = this.yBound - 1;
                            if (0 > max1)
                            {
                                throw new Exception("FAIL: min <= max");
                            }

                            this.y = (value1 < 0) ? 0 : ((value1 > max1) ? max1 : value1);
                            break;
                        }


                    case 1:
                        {
                            int value2 = this.rx + -16 + ((int)global::System.Math.Floor((double)(33 * global::HaxeMath.rand.NextDouble())));
                            int max2 = this.xBound - 1;
                            if (1 > max2)
                            {
                                throw new Exception("FAIL: min <= max");
                            }

                            this.rx = (value2 < 1) ? 1 : ((value2 > max2) ? max2 : value2);
                            break;
                        }


                    case 2:
                        {
                            int value3 = this.ry + -16 + ((int)global::System.Math.Floor((double)(33 * global::HaxeMath.rand.NextDouble())));
                            int max3 = this.xBound - 1;
                            if (1 > max3)
                            {
                                throw new Exception("FAIL: min <= max");
                            }

                            this.ry = (value3 < 1) ? 1 : ((value3 > max3) ? max3 : value3);
                            break;
                        }


                }

            }
        }


        public virtual IShape Clone()
        {
            return new Ellipse(xBound, yBound)
            {
                x = this.x,
                y = this.y,
                rx = this.rx,
                ry = this.ry
            };
        }

        public virtual double[] GetRawShapeData()
        {
            return new double[]
            {
                x, y, rx, ry
            };
        }
    }
}


