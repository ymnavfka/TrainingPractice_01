using System;
using System.IO;

namespace MND_Task_05
{
    class Program
    {
        static void Main(string[] args)
        {
            const string mapName = "levelMap";
            char[,] map = ReadMap(mapName, out int startPointX, out int startPointY,
                                  out int endPointX, out int endPointY);
            string[] newFile = File.ReadAllLines($"maps/{mapName}.txt");

            DrawMap(map);
            Console.SetCursorPosition(map.GetLength(1) + 5, 0);
            Console.Write("Motion control:");
            Console.SetCursorPosition(map.GetLength(1) + 5, 1);
            Console.Write("w - up");
            Console.SetCursorPosition(map.GetLength(1) + 5, 2);
            Console.Write("s - down");
            Console.SetCursorPosition(map.GetLength(1) + 5, 3);
            Console.Write("a - left");
            Console.SetCursorPosition(map.GetLength(1) + 5, 4);
            Console.Write("d - right");
            Console.SetCursorPosition(map.GetLength(1) + 25, 0);
            Console.SetCursorPosition(1, 1);
            MovePlayer(map, startPointX, startPointY, endPointX, endPointY);
            Console.ReadKey();
        }

        static void MovePlayer(char[,] map, int startPointX, int startPointY, int endPointX, int endPointY)
        {
            int x = startPointX;
            int y = startPointY;
            int nextStepX = x;
            int nextStepY = y;
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.S:
                    nextStepY++;
                    if (!((map[nextStepY, x] == '=') || (map[nextStepY, x] == '|')))
                        y = nextStepY;
                    break;

                case ConsoleKey.W:
                    nextStepY--;
                    if (!((map[nextStepY, x] == '=') || (map[nextStepY, x] == '|')))
                        y = nextStepY;
                    break;

                case ConsoleKey.D:
                    nextStepX++;
                    if (!((map[y, nextStepX] == '=') || (map[y, nextStepX] == '|')))
                        x = nextStepX;
                    break;

                case ConsoleKey.A:
                    nextStepX--;
                    if (!((map[y, nextStepX] == '=') || (map[y, nextStepX] == '|')))
                        x = nextStepX;
                    break;
                default:
                    MovePlayer(map, x, y, endPointX, endPointY);
                    break;
            }
            if (x == endPointX && y == endPointY)
            {
                Console.SetCursorPosition(map.GetLength(1) + 5, 7);
                Console.WriteLine("You have passed the maze!");
                Console.SetCursorPosition(x, y);
                return;
            }
            Console.SetCursorPosition(x, y);
            MovePlayer(map, x, y, endPointX, endPointY);
        }

        static char[,] ReadMap(string mapName, out int startPointX, out int startPointY,
                               out int endPointX, out int endPointY)
        {
            startPointX = 0;
            startPointY = 0;
            endPointX = 0;
            endPointY = 0;

            string[] newFile = File.ReadAllLines($"maps/{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i, j] == '>')
                    {
                        startPointX = j;
                        startPointY = i;
                    }
                    if (map[i, j] == '<')
                    {
                        endPointX = j;
                        endPointY = i;
                    }
                }
            }
            return map;
        }


        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
