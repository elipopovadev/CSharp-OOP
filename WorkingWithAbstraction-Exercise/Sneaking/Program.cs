using System;
using System.Collections.Generic;
using System.Linq;

namespace Sneaking
{
    public class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] room = new char[rows][];
            int currentRowSam = 0;
            int currentColSam = 0;
            int rowNikoladze = 0;
            int colNikoladze = 0;
            var coordinatesWithEnemies = new Queue<int[]>();
            CreateRoomWithAllPlayers(rows, room, ref currentRowSam, ref currentColSam, ref rowNikoladze, ref colNikoladze, coordinatesWithEnemies);

            string commandArray = Console.ReadLine();
            for (int k = 0; k < commandArray.Length; k++)
            {              
                char command = commandArray[k];
                room[currentRowSam][currentColSam] = '.';
                int cols = room[0].Length;
                MoveEnemies(cols, coordinatesWithEnemies, room);
                foreach (var enemyCoordinates in coordinatesWithEnemies)
                {
                    int enemyRow = enemyCoordinates[0];
                    int enemyCol = enemyCoordinates[1];
                    if (room[enemyRow][enemyCol] == 'b' && enemyRow == currentRowSam && enemyCol < currentColSam)
                    {
                        DocumentSamDead(currentRowSam, currentColSam, room);
                    }

                    if (room[enemyRow][enemyCol] == 'd' && enemyRow == currentRowSam && enemyCol > currentColSam)
                    {
                        DocumentSamDead(currentRowSam, currentColSam, room);
                    }
                }

                switch (command)
                {
                    case 'U':
                        currentRowSam--;
                        break;
                    case 'D':
                        currentRowSam++;
                        break;
                    case 'L':
                        currentColSam--;
                        break;
                    case 'R':
                        currentColSam++;
                        break;
                    case 'W':
                        continue;
                }

                if (currentRowSam == rowNikoladze)
                {
                    room[currentRowSam][currentColSam] = 'S';
                    DocumentNikoladzeDead(rowNikoladze, colNikoladze, room);
                }

                else if (room[currentRowSam][currentColSam] == 'b' || room[currentRowSam][currentColSam] == 'd')
                {
                    DocumentEnemyDead(currentRowSam, currentColSam, coordinatesWithEnemies, room);
                }

                else if (room[currentRowSam][currentColSam] == '.')
                {
                    room[currentRowSam][currentColSam] = 'S';
                }
            }
        }

        
        private static void DocumentNikoladzeDead(int rowNikoladze, int colNikoladze, char[][]room)
        {
            room[rowNikoladze][colNikoladze] = 'X';
            Console.WriteLine("Nikoladze killed!");
            PrintTheRoom(room);
        }

        private static void DocumentEnemyDead(int currentRowSam, int currentColSam, Queue<int[]> coordinatestWithEnemies, char[][] room)
        {
            room[currentRowSam][currentColSam] = 'S';
            for (int i = 0; i < coordinatestWithEnemies.Count; i++)
            {
                int[] enemiesArray = coordinatestWithEnemies.Dequeue();
                if (enemiesArray[0] == currentRowSam && enemiesArray[1] == currentColSam)
                {
                    break;
                }

                coordinatestWithEnemies.Enqueue(enemiesArray);
            }
        }

        private static void DocumentSamDead(int currentRowSam, int currentColSam, char[][] room)
        {
            room[currentRowSam][currentColSam] = 'X';
            Console.WriteLine($"Sam died at {currentRowSam}, {currentColSam}");
            PrintTheRoom(room);
        }

        private static void MoveEnemies(int cols, Queue<int[]> coordinatestWithEnemies, char[][] room)
        {
            for (int i = 0; i <= coordinatestWithEnemies.Count - 1; i++)
            {
                int[] enemy = coordinatestWithEnemies.Dequeue();
                int rowEnemy = enemy[0];
                int colEnemy = enemy[1];
                if (room[rowEnemy][colEnemy] == 'b' && colEnemy != cols-1)
                {
                    room[rowEnemy][colEnemy] = '.';
                    int newColEnemy = colEnemy + 1;
                    room[rowEnemy][newColEnemy] = 'b';
                    coordinatestWithEnemies.Enqueue(new int[] { rowEnemy, newColEnemy });
                }

                else if (room[rowEnemy][colEnemy] == 'b' && colEnemy == cols-1)
                {
                    room[rowEnemy][colEnemy] = 'd';
                    coordinatestWithEnemies.Enqueue(new int[] { rowEnemy, colEnemy });
                }

                else if (room[rowEnemy][colEnemy] == 'd' && colEnemy != 0)
                {
                    room[rowEnemy][colEnemy] = '.';
                    int newColEnemy = colEnemy - 1;
                    room[rowEnemy][newColEnemy] = 'd';
                    coordinatestWithEnemies.Enqueue(new int[] { rowEnemy, newColEnemy });
                }

                else if (room[rowEnemy][colEnemy] == 'd' && colEnemy == 0)
                {
                    room[rowEnemy][colEnemy] = 'b';
                    coordinatestWithEnemies.Enqueue(new int[] { rowEnemy, colEnemy });
                }
            }
        }

        private static void PrintTheRoom(char[][]room)
        {
            foreach (var currentRow in room) 
            {
                Console.WriteLine(string.Join("", currentRow));
            }

            Environment.Exit(0);
        }

        private static void CreateRoomWithAllPlayers(int rows, char[][] room, ref int currentRowSam, ref int currentColSam, ref int rowNikoladze, ref int colNikoladze, Queue<int[]> coordinatestWithEnemies)
        {
            for (int row = 0; row < rows; row++)
            {
                string currentRow = Console.ReadLine();
                room[row] = currentRow.ToCharArray();
                if (room[row].Contains('S'))
                {
                    int col = Array.IndexOf(room[row], 'S');
                    currentRowSam = row;
                    currentColSam = col;
                }

                if (room[row].Contains('N'))
                {
                    int col = Array.IndexOf(room[row], 'N');
                    rowNikoladze = row;
                    colNikoladze = col;
                }

                if (room[row].Contains('b'))
                {
                    int col = Array.IndexOf(room[row], 'b');
                    int[] enemies = new int[2];
                    enemies[0] = row;
                    enemies[1] = col;
                    coordinatestWithEnemies.Enqueue(enemies);
                }

                if (room[row].Contains('d'))
                {
                    int col = Array.IndexOf(room[row], 'd');
                    int[] enemies = new int[2];
                    enemies[0] = row;
                    enemies[1] = col;
                    coordinatestWithEnemies.Enqueue(enemies);
                }
            }
        }
    }
}
