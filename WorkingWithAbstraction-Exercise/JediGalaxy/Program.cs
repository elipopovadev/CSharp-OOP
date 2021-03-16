using System;
using System.Linq;

namespace JediGalaxy
{
   public class Program
    {
        static void Main(string[] args)
        {
            int[] arrayInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int matrixRows = arrayInfo[0];
            int matrixCols = arrayInfo[1];
            int[,] matrix = CreateMatrix(matrixRows, matrixCols);
            long sumOfStars = 0;
            string line = Console.ReadLine();
            while (line != "Let the Force be with you")
            {
                int[] ivoCoordinates = line.Split().Select(int.Parse).ToArray();
                int ivoRow = ivoCoordinates[0];
                int ivoCol = ivoCoordinates[1];
           
                int[] evilCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int evilRow = evilCoordinates[0];
                int evilCol = evilCoordinates[1];

                while(evilRow >= 0 && evilCol >= 0)
                {                    
                    EvilDestroysStars(matrixRows, matrixCols, matrix, evilRow, evilCol);
                    evilRow--;
                    evilCol--;
                }

                while (ivoRow >= 0 && ivoCol <= matrixCols - 1)
                {                   
                    sumOfStars = IvoCollectsStars(matrixRows, matrixCols, matrix, sumOfStars, ivoRow, ivoCol);
                    ivoRow--;
                    ivoCol++;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(sumOfStars);
        }


        private static long IvoCollectsStars(int matrixRows, int matrixCols, int[,] matrix, long sumOfStars, int ivoRow, int ivoCol)
        {
            if (ivoRow >= 0 && ivoRow < matrixRows && ivoCol >= 0 && ivoCol < matrixCols)
            {
                sumOfStars += matrix[ivoRow, ivoCol];
            }

            return sumOfStars;
        }

        private static void EvilDestroysStars(int matrixRows, int matrixCols, int[,] matrix, int evilRow, int evilCol)
        {
            if (evilRow >= 0 && evilRow < matrixRows && evilCol >= 0 && evilCol < matrixCols)
            {
                matrix[evilRow, evilCol] = 0;
            }
        }

        private static int[,] CreateMatrix(int matrixRows, int matrixCols)
        {
            int[,] matrix = new int[matrixRows, matrixCols];
            int value = 0;
            for (int row = 0; row < matrixRows; row++)
            {
                for (int col = 0; col < matrixCols; col++)
                {
                    matrix[row, col] = value;
                    value++;
                }
            }

            return matrix;
        }
    }
}
