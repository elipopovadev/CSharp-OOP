using System.Text;

namespace Shapes
{
   public class Rectangle : Shape
    {
        private int height;
        private int width;
        public Rectangle(int height, int width) : base()
        {
            this.Height = height;
            this.Width = width;
        }

        public int Width
        {
            get { return width; }
            private set { width = value; }
        }

        public int Height
        {
            get { return height; }
            private set { height = value; }
        }

        public override double CalculateArea()
        {
            int area = this.Width * this.Height;
            return area;
        }

        public override double CalculatePerimeter()
        {
            int perimeter = 2 * (this.Height + this.Width);
            return perimeter;
        }

        public override string Draw()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < this.Height; i++)
            {

                sb.AppendLine(new string('*', this.Width));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
