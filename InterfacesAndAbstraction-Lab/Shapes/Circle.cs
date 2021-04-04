using System;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private int radius;

        public Circle(int radius)
        {
            this.Radius = radius;
        }

        public int Radius
        {
            get => radius;
            set
            {
                if (value > 0)
                {
                    radius = value;
                }
            }
        }

        public void Draw()
        {
            double consoleRatio = Convert.ToDouble(4.0 / 2.0);
            double a = consoleRatio * radius;
            double b = radius;

            for (double y = -radius; y <= radius; y++)
            {
                for (double x = -a; x <= a; x++)
                {
                    double d = (x / a) * (x / a) + (y / b) * (y / b);
                    if (d > 1 && d < 1.2)
                    {
                        Console.Write('*');
                    }

                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
