using System;
using System.Linq;

namespace PointInRectangle
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] rectangleInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int topLeftX = rectangleInfo[0];
            int topLeftY = rectangleInfo[1];
            Point topLeftPoint = new Point(topLeftX, topLeftY);
            int bottomRightX = rectangleInfo[2];
            int bottomRightY = rectangleInfo[3];
            Point bottomRightPoint = new Point(bottomRightX, bottomRightY);
            Rectangle rectangle = new Rectangle(topLeftPoint, bottomRightPoint);

            int numberOfPoints = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPoints; i++)
            {
                int[] pointInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int x = pointInfo[0];
                int y = pointInfo[1];
                Point newPoint = new Point(x, y);
                Console.WriteLine(rectangle.Contains(newPoint));
            }          
        }
    }
}
