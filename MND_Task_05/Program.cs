using System;

namespace MND_Task_05
{
    class Program
    {
        static string[] map;

        static void Main(string[] args)
        {
            int movesGive = 120;
            const int mapSize = 20;
            map = new string[mapSize] { "========================================",
                                        "| |             |              =====|  |",
                                        "|               |  |                |  |",
                                        "| |======  == = |  |=========       |  |",
                                        "|               |  |        | |     |  |",
                                        "|========       |           | |     |  |",
                                        "||      |       |======     | |     |  |",
                                        "||      |   | |       |     | |     |  |",
                                        "||      |   | |====         | |        |",
                                        "||      |   | |             | |        |",
                                        "|       |             |=======|  |===| |",
                                        "|       |             |     | |  |   | |",
                                        "|       |             |     | |  |===| |",
                                        "|       |===========  |  ===|          |",
                                        "|                  |  |  |     ===|    |",
                                        "|                  |  |           |    |",
                                        "|  |=   =|         |  |      |         |",
                                        "| |=     =|        |===      |===      |",
                                        "| |       |                            |",
                                        "====|   |==============================="};
            WriteArr(map);
            Console.SetCursorPosition(45, 0);
            Console.Write("Your task is to complete the maze in 65 moves");
            Console.SetCursorPosition(45, 2);
            Console.Write("Motion control:");
            Console.SetCursorPosition(45, 3);
            Console.Write("w - up");
            Console.SetCursorPosition(45, 4);
            Console.Write("s - down");
            Console.SetCursorPosition(45, 5);
            Console.Write("a - left");
            Console.SetCursorPosition(45, 6);
            Console.Write("d - right");
            Console.SetCursorPosition(1, 1);
            MovePlayer(1, 1, map, movesGive);
            Console.ReadKey();
        }

        static void WriteArr(string[] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++, Console.WriteLine())
                Console.Write(arr[i]);
        }

        static void MovePlayer(int x, int y, string[] map, int moves)
        {
            int nextStepX = x;
            int nextStepY = y;
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.S:
                    nextStepY++;
                    if ((map[nextStepY][x] == '=') || (map[nextStepY][x] == '|'))
                        nextStepY = y;
                    else
                    {
                        y = nextStepY;
                        moves--;
                    }
                    if (y == (map.Length - 1))
                    {
                        Console.SetCursorPosition(45, 2);
                        Console.WriteLine("You have passed the maze!");
                        Console.SetCursorPosition(x, y);
                        return;
                    }
                    break;

                case ConsoleKey.W:
                    nextStepY--;
                    if ((map[nextStepY][x] == '=') || (map[nextStepY][x] == '|'))
                        nextStepY = y;
                    else
                    {
                        y = nextStepY;
                        moves--;
                    }
                    break;

                case ConsoleKey.D:
                    nextStepX++;
                    if ((map[y][nextStepX] == '=') || (map[y][nextStepX] == '|'))
                        nextStepX = x;
                    else
                    {
                        x = nextStepX;
                        moves--;
                    }
                    break;

                case ConsoleKey.A:
                    nextStepX--;
                    if ((map[y][nextStepX] == '=') || (map[y][nextStepX] == '|'))
                        nextStepX = x;
                    else
                    {
                        x = nextStepX;
                        moves--;
                    }
                    break;
            }
            if (moves == 0)
            {
                Console.SetCursorPosition(45, 2);
                Console.WriteLine("You've spent all your moves :(");
                Console.SetCursorPosition(45, 3);
                return;
            }
            Console.SetCursorPosition(45, 0);
            WriteInfo(moves);
            Console.SetCursorPosition(x, y);
            MovePlayer(x, y, map, moves);
        }

        static void WriteInfo(int moves)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            WriteArr(map);
            Console.SetCursorPosition(50, 0);
            Console.WriteLine($"Moves left: {moves}");
        }
    }
}
