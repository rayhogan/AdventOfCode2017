using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    class Day19
    {
        public static void Run()
        {
            // Read Input File
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\\Day19.txt");

            // Create maze
            char[,] maze = new char[lines[0].Length, lines.Count()];
            PopulateMaze(lines, ref maze);

            //PrintMaze(ref maze);


            Parts1and2(ref maze);

        }

        private static void Parts1and2(ref char[,] maze)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            int steps = 0;
            string result = TraverseMaze(ref maze, ref steps);

            Console.WriteLine("Result: " + result);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Result: " + steps);
        }


        private static void PopulateMaze(string[] lines, ref char[,] maze)
        {
            for (int i = 0; i < lines.Count(); i++)
            {
                char[] split = lines[i].ToCharArray();
                for (int j = 0; j < split.Count(); j++)
                {
                    maze[j, i] = split[j];
                }
            }
        }

        private static void PrintMaze(ref char[,] maze)
        {
            for (int x = 0; x < maze.GetLength(1); x++)
            {
                for (int y = 0; y < maze.GetLength(0); y++)
                {
                    var val = maze[y, x];

                    Console.Write(val);
                }
                Console.WriteLine();
            }
        }

        private static string TraverseMaze(ref char[,] maze, ref int steps)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder output = new StringBuilder();

            MazeDirection direction = MazeDirection.Down;
            int x = 0;
            int y = 0;

            bool travsering = true;

            // Find starting position
            for (int k = 0; k < 1; k++)
            {
                for (int l = 0; l < maze.GetLength(0); l++)
                {
                    var val = maze[l, k];
                    if (val == '|')
                    {
                        x = k;
                        y = l;
                        break;
                    }
                }
            }

            while (travsering)
            {

                if (direction == MazeDirection.Down)
                {
                    x++;
                    if (!CheckBounds(x, y, ref maze))
                    {
                        travsering = false;

                    }
                    else if (ContainsLetter(x, y, ref maze))
                    {
                        output.Append(maze[y, x]);
                    }
                    else if (maze[y, x] == '+')
                    {
                        // Check Left
                        if (CheckBounds(x, y - 1, ref maze))
                        {
                            if (maze[y - 1, x] == '-' || alphabet.ToCharArray().Contains(maze[y - 1, x]))
                            {
                                direction = MazeDirection.Left;
                            }

                        }

                        // Check Right
                        if (CheckBounds(x, y + 1, ref maze))
                        {
                            if (maze[y + 1, x] == '-' || alphabet.ToCharArray().Contains(maze[y + 1, x]))
                            {
                                direction = MazeDirection.Right;
                            }

                        }

                    }


                }
                else if (direction == MazeDirection.Up)
                {
                    x--;
                    if (!CheckBounds(x, y, ref maze))
                    {
                        travsering = false;

                    }
                    else if (ContainsLetter(x, y, ref maze))
                    {
                        output.Append(maze[y, x]);
                    }
                    else if (maze[y, x] == '+')
                    {
                        // Check Left
                        if (CheckBounds(x, y - 1, ref maze))
                        {
                            if (maze[y - 1, x] == '-' || alphabet.ToCharArray().Contains(maze[y - 1, x]))
                            {
                                direction = MazeDirection.Left;
                            }

                        }

                        // Check Right
                        if (CheckBounds(x, y + 1, ref maze))
                        {
                            if (maze[y + 1, x] == '-' || alphabet.ToCharArray().Contains(maze[y + 1, x]))
                            {
                                direction = MazeDirection.Right;
                            }

                        }

                    }
                }
                else if (direction == MazeDirection.Left)
                {
                    y--;
                    if (!CheckBounds(x, y, ref maze))
                    {
                        travsering = false;

                    }
                    else if (ContainsLetter(x, y, ref maze))
                    {
                        output.Append(maze[y, x]);
                    }
                    else if (maze[y, x] == '+')
                    {
                        // Check Up
                        if (CheckBounds(x - 1, y, ref maze))
                        {
                            if (maze[y, x - 1] == '|' || alphabet.ToCharArray().Contains(maze[y, x - 1]))
                            {
                                direction = MazeDirection.Up;
                            }

                        }

                        // Check Down
                        if (CheckBounds(x + 1, y, ref maze))
                        {
                            if (maze[y, x + 1] == '|' || alphabet.ToCharArray().Contains(maze[y, x + 1]))
                            {
                                direction = MazeDirection.Down;
                            }

                        }

                    }
                }
                else if (direction == MazeDirection.Right)
                {
                    y++;
                    if (!CheckBounds(x, y, ref maze))
                    {
                        travsering = false;

                    }
                    else if (ContainsLetter(x, y, ref maze))
                    {
                        output.Append(maze[y, x]);
                    }
                    else if (maze[y, x] == '+')
                    {
                        // Check Up
                        if (CheckBounds(x - 1, y, ref maze))
                        {
                            if (maze[y, x - 1] == '|' || alphabet.ToCharArray().Contains(maze[y, x - 1]))
                            {
                                direction = MazeDirection.Up;
                            }

                        }

                        // Check Down
                        if (CheckBounds(x + 1, y, ref maze))
                        {
                            if (maze[y, x + 1] == '|' || alphabet.ToCharArray().Contains(maze[y, x + 1]))
                            {
                                direction = MazeDirection.Down;
                            }

                        }

                    }
                    
                }
                else
                    Console.WriteLine("! E R R O R !");
                steps++;
            }

            return output.ToString();
        }

        private static bool ContainsLetter(int x, int y, ref char[,] maze)
        {
            if ("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().Contains(maze[y, x]))
            {
                return true;
            }
            else
                return false;
        }

        private static bool CheckBounds(int x, int y, ref char[,] maze)
        {
            if (y < maze.GetLength(0) && x < maze.GetLength(1) && y >= 0 && x >= 0)
            {
                if (maze[y, x] == ' ')
                    return false;
                else
                    return true;
            }
            else
                return false;
        }

        public enum MazeDirection
        {
            Down = 0,
            Up = 1,
            Left = 2,
            Right = 3,
        }
    }
}
