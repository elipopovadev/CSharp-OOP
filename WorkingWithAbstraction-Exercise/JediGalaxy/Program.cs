using System;
using System.Linq;

namespace JediGalaxy
{
   public class Program
    {
        static void Main(string[] args)
        {
            int[] arrayInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int matrixRows = arrayInfo[0];
            int matrixCols = arrayInfo[1];
            int[,] matrix = CreateMatrix(matrixRows, matrixCols);
            long sumOfStars = 0;
            string line = Console.ReadLine();
            while (line != "Let the Force be with you")
            {
                long[] ivoCoordinates = line.Split().Select(long.Parse).ToArray();
                long ivoRow = ivoCoordinates[0];
                long ivoCol = ivoCoordinates[1];
                long ivoStartRow = 0;
                long ivoStartCol = 0;
                ValidateIvoStart(matrixRows, ivoRow, ivoCol, out ivoStartRow, out ivoStartCol);

                long[] evilsCoordinates = Console.ReadLine().Split().Select(long.Parse).ToArray();
                long evilRow = evilsCoordinates[0];
                long evilCol = evilsCoordinates[1];
                long evilStartRow = 0;
                long evilStartCol = 0;
                ValidateEvilStart(matrixRows, matrixCols, evilRow, evilCol, out evilStartRow, out evilStartCol);

                while (evilStartRow > 0 && evilStartCol > 0)
                {
                    EvilDestroysStars(matrix, ref evilStartRow, ref evilStartCol);
                }

                if (ivoStartRow <= matrixRows - 1 && ivoStartCol >= 0 && ivoStartCol <= matrixCols - 1)
                {
                    sumOfStars += matrix[ivoStartRow, ivoStartCol]; // if Ivo's start is in the matrix, he collects the current star
                }

                while (ivoStartRow > 0 && ivoStartCol < matrixCols - 1)
                {
                    IvoCollectsStars(matrix, ref sumOfStars, ref ivoStartRow, ref ivoStartCol);
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(sumOfStars);
        }


        private static void IvoCollectsStars(int[,] matrix, ref long sum, ref long ivoStartRow, ref long ivoStartCol)
        {
            ivoStartRow--;
            ivoStartCol++;
            sum += matrix[ivoStartRow, ivoStartCol];
        }

        private static void EvilDestroysStars(int[,] matrix, ref long evilStartRow, ref long evilStartCol)
        {
            evilStartRow--;
            evilStartCol--;
            matrix[evilStartRow, evilStartCol] = 0;
        }

        private static void ValidateEvilStart(int matrixRows, int matrixCols, long evilRow, long evilCol, out long evilStartRow, out long evilStartCol)
        {
            if (evilRow > matrixRows - 1)
            {
                evilStartRow = matrixRows;
            }

            else
            {
                evilStartRow = evilRow;
            }

            if (evilCol > matrixCols)
            {
                evilStartCol = matrixCols;
            }

            else
            {
                evilStartCol = evilCol;
            }
        }

        private static void ValidateIvoStart(int matrixRows, long ivoRow, long ivoCol, out long ivoStartRow, out long ivoStartCol)
        {
            if (ivoRow > matrixRows - 1)
            {
                ivoStartRow = matrixRows;
            }

            else
            {
                ivoStartRow = ivoRow;
            }

            if (ivoCol < 0)
            {
                ivoStartCol = -1;
            }

            else
            {
                ivoStartCol = ivoCol;
            }
        }

        private static int[,] CreateMatrix(int matrixRows, int matrixCols)
        {
            int[,] matrix = new int[matrixRows, matrixCols];
            int currentNum = 0;
            for (int row = 0; row < matrixRows; row++)
            {
                for (int col = 0; col < matrixCols; col++)
                {
                    matrix[row, col] = currentNum;
                    currentNum++;
                }
            }

            return matrix;
        }
    }
}
