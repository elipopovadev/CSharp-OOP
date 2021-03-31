using System;
using System.IO;

namespace ClassBoxData
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                Box newBox = new Box(length, width, height);
                Console.WriteLine(newBox.ToString());
            }

            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine(exception);
            }          
        }
    }
}
