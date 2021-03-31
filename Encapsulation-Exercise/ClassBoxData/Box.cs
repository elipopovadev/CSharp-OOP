using System.Text;
using System;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        private double Length
        {
            get => this.length;
            set
            {
                if (value > 0)
                {
                    this.length = value;
                }

                else
                {
                    throw new ArgumentOutOfRangeException("Length cannot be zero or negative.");
                }
            }
        }
        private double Width 
        {
            get => this.width;
            set
            {
                if (value > 0)
                {
                    this.width = value;
                }

                else
                {
                    throw new ArgumentOutOfRangeException("Width cannot be zero or negative.");
                }
            }
        }

        private double Height
        {
            get => this.height;
            set
            {
                if (value > 0)
                {
                    this.height = value;
                }

                else
                {
                    throw new ArgumentOutOfRangeException("Height cannot be zero or negative.");
                }
            }
        }

        private double CalculateSurfaceArea()
        {
            double surfaceArea = (2 * Length * Width) + (2 * Width * Height) + (2*length * height);
            return surfaceArea;
        }

        private double CalculateLateralArea()
        {
            double lateralArea = (2 * Length * Height) + (2 * Width * Height);
            return lateralArea;              
        }

        private double CalculateVolume()
        {
            double volume = Length * Width * Height;
            return volume;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.CalculateSurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {this.CalculateLateralArea():f2}");
            sb.AppendLine($"Volume - {this.CalculateVolume():f2}");
            return sb.ToString().TrimEnd();
        }
    }
}
