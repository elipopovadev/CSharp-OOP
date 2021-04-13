using System;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private int radius;
        public Circle(int radius) : base()
        {
            this.Radius = radius;
        }

        public int Radius
        {
            get { return radius; }
            private set { radius = value; }
        }
            
        public override double CalculateArea()
        {
            double area = Math.PI * Math.Pow(this.Radius,2);
            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override string Draw()
        {
            double consoleRatio = Convert.ToDouble(4.0 / 2.0);
            double a = consoleRatio * radius;
            double b = radius;
            var sb = new StringBuilder();

            for (double y = -radius; y <= radius; y++)
            {
                for (double x = -a; x <= a; x++)
                {
                    double d = (x / a) * (x / a) + (y / b) * (y / b);
                    if (d > 1 && d < 1.2)
                    {
                        sb.Append('*');
                    }

                    else
                    {
                        sb.Append(" ");
                    }
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
