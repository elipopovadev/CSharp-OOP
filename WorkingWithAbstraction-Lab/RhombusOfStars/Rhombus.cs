using System;

namespace RhombusOfStars
{
    public class Rhombus
    {
        public Rhombus(int size)
        {
            this.Size = size;
        }

        public int Size { get; }

        public void PrintTop()
        {
            for (int row = 0; row < this.Size - 1; row++)
            {
                Console.Write(new string(' ', this.Size - 1 - row));
                Console.WriteLine(string.Join(' ', new string('*', row + 1).ToCharArray()));
            }
        }

        public void PrintMiddle()
        {
            Console.WriteLine(string.Join(' ', new string('*', this.Size).ToCharArray()));
        }

        public void PrintBottom()
        {
            for (int row = this.Size - 2; row >= 0; row--)
            {
                Console.Write(new string(' ', this.Size - 1 - row));
                Console.WriteLine(string.Join(' ', new string('*', row + 1).ToCharArray()));
            }
        }
    }
}
