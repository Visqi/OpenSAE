// Generated by Haxe 4.3.1

#pragma warning disable 109, 114, 219, 429, 168, 162
using System;

namespace Geometrize.Shape
{
    public class Circle : Ellipse
    {
        public Circle(int xBound, int yBound)
            : base(xBound, yBound)
        {
            ry = rx;
        }

        public override void Mutate()
        {
            unchecked
            {
                int r = global::Std.random(2);
                switch (r)
                {
                    case 0:
                        {
                            int @value = (this.x + ((-16 + ((int)(global::System.Math.Floor(((double)((33 * global::HaxeMath.rand.NextDouble())))))))));
                            int max = (this.xBound - 1);
                            if ((0 > max))
                            {
                                throw new Exception("FAIL: min <= max");
                            }

                            this.x = (((@value < 0)) ? (0) : ((((@value > max)) ? (max) : (@value))));
                            int value1 = (this.y + ((-16 + ((int)(global::System.Math.Floor(((double)((33 * global::HaxeMath.rand.NextDouble())))))))));
                            int max1 = (this.yBound - 1);
                            if ((0 > max1))
                            {
                                throw new Exception("FAIL: min <= max");
                            }

                            this.y = (((value1 < 0)) ? (0) : ((((value1 > max1)) ? (max1) : (value1))));
                            break;
                        }


                    case 1:
                        {
                            int value2 = (this.rx + ((-16 + ((int)(global::System.Math.Floor(((double)((33 * global::HaxeMath.rand.NextDouble())))))))));
                            int max2 = (this.xBound - 1);
                            if ((1 > max2))
                            {
                                throw new Exception("FAIL: min <= max");
                            }

                            int r1 = (((value2 < 1)) ? (1) : ((((value2 > max2)) ? (max2) : (value2))));
                            this.rx = r1;
                            this.ry = r1;
                            break;
                        }


                }

            }
        }


        public override IShape Clone()
        {
            return new Circle(xBound, yBound)
            {
                x = x,
                y = y,
                rx = rx,
                ry = ry,
            };
        }

        public override double[] GetRawShapeData()
        {
            return new double[]
            {
                x, y, rx
            };
        }
    }
}


