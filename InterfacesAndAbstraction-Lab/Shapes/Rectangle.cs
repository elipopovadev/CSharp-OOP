using System;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width { get; }
        public int Height { get; }

        public void Draw()
        {
            for (int i = 0; i < this.Height; i++)
            {
                Console.WriteLine(new string('*', this.Width));
            }
        }
    }
}
