using System;

namespace RhombusOfStars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Rhombus currentRhombus = new Rhombus(n);
            currentRhombus.PrintTop();
            currentRhombus.PrintMiddle();
            currentRhombus.PrintBottom();
        }
    }
}




