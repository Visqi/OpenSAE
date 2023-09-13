// Generated by Haxe 4.3.1

#pragma warning disable 109, 114, 219, 429, 168, 162
using geometrize.rasterizer;
using System;
using System.Collections.Generic;

namespace geometrize.shape
{
    public class Rectangle : Shape
    {
        public Rectangle(int xBound, int yBound)
        {
            x1 = Std.random(xBound);
            y1 = Std.random(yBound);
            int @value = x1 + Std.random(32) + 1;
            int max = xBound - 1;
            if (0 > max)
            {
                throw new Exception("FAIL: min <= max");
            }

            x2 = (@value < 0) ? 0 : ((@value > max) ? max : @value);
            int value1 = y1 + Std.random(32) + 1;
            int max1 = yBound - 1;
            if (0 > max1)
            {
                throw new Exception("FAIL: min <= max");
            }

            y2 = (value1 < 0) ? 0 : ((value1 > max1) ? max1 : value1);
            this.xBound = xBound;
            this.yBound = yBound;
        }

        public int x1;

        public int y1;

        public int x2;

        public int y2;

        public int xBound;

        public int yBound;

        public virtual IReadOnlyList<Scanline> rasterize()
        {
            var lines = new List<Scanline>();

            for (int y = y1; y <= y2; y++)
            {
                if (this.x1 != this.x2)
                {
                    lines.Add(new Scanline(y, Math.Min(x1, x2), Math.Max(x1, x2)));
                }
            }

            return lines;
        }


        public virtual void mutate()
        {
            unchecked
            {
                int r = Std.random(2);
                switch (r)
                {
                    case 0:
                        {
                            int @value = this.x1 + -16 + ((int)global::System.Math.Floor((double)(33 * HaxeMath.rand.NextDouble())));
                            int max = this.xBound - 1;
                            if (0 > max)
                            {
                                throw new Exception("FAIL: min <= max");
                            }

                            this.x1 = (@value < 0) ? 0 : ((@value > max) ? max : @value);
                            int value1 = this.y1 + -16 + ((int)global::System.Math.Floor((double)(33 * HaxeMath.rand.NextDouble())));
                            int max1 = this.yBound - 1;
                            if (0 > max1)
                            {
                                throw new Exception("FAIL: min <= max");
                            }

                            this.y1 = (value1 < 0) ? 0 : ((value1 > max1) ? max1 : value1);
                            break;
                        }


                    case 1:
                        {
                            int value2 = this.x2 + -16 + ((int)global::System.Math.Floor((double)(33 * HaxeMath.rand.NextDouble())));
                            int max2 = this.xBound - 1;
                            if (0 > max2)
                            {
                                throw new Exception("FAIL: min <= max");
                            }

                            this.x2 = (value2 < 0) ? 0 : ((value2 > max2) ? max2 : value2);
                            int value3 = this.y2 + -16 + ((int)global::System.Math.Floor((double)(33 * HaxeMath.rand.NextDouble())));
                            int max3 = this.yBound - 1;
                            if (0 > max3)
                            {
                                throw new Exception("FAIL: min <= max");
                            }

                            this.y2 = (value3 < 0) ? 0 : ((value3 > max3) ? max3 : value3);
                            break;
                        }


                }

            }
        }


        public virtual Shape clone()
        {
            return new Rectangle(xBound, yBound)
            {
                x1 = x1,
                y1 = y1,
                x2 = x2,
                y2 = y2
            };
        }


        public virtual int getType() => 0;


        public virtual double[] getRawShapeData()
        {
            return new double[]
            {
                Math.Min(x1, x2),
                Math.Min(y1, y2),
                Math.Max(x1, x2),
                Math.Max(y1, y2)
            };
        }
    }
}


