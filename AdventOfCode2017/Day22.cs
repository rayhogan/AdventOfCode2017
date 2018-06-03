using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AdventOfCode2017
{
    class Day22
    {
        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\\Day22.txt");

            Part1(lines);
            Part2(lines);
        }

        enum Orientation
        {
            North = 1,
            East = 2,
            South = 3,
            West = 4
        }

        private static void Part1(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            List<Point> originalList = BuildInfectedList(input);
            List<Point> workingList = BuildInfectedList(input);

            int x = 0;
            int y = 0;
            Orientation orientation = Orientation.North;

            int counter = 10000;
            int infectionCount = 0;

            for (int i = 0; i < counter; i++)
            {
                //Console.WriteLine(x + "," + y);
                if (workingList.Contains(new Point(x, y)))
                {
                    // Currently infected

                    //Turn Right -- calculate new orientation
                    int orient = (int)orientation;
                    orient++;
                    if (orient >= 5) { orient = 1; }
                    orientation = (Orientation)orient;

                    workingList.Remove(new Point(x, y));
                }
                else
                {
                    // Not infected

                    //Turn left -- calculate new orientation
                    int orient = (int)orientation;
                    orient--;
                    if (orient <= 0) { orient = 4; }
                    orientation = (Orientation)orient;

                    workingList.Add(new Point(x, y));

                    infectionCount++;
                }

                // Move forward
                if (orientation == Orientation.North)
                {
                    x--;
                }
                else if (orientation == Orientation.East)
                {
                    y++;
                }
                else if (orientation == Orientation.South)
                {
                    x++;
                }
                else
                {
                    y--;
                }

            }

            Console.WriteLine("Infection Count: " + infectionCount);
        }

        private static void Part2(string[] input)
        {
            Dictionary<Tuple<int,int>, char> infected = new Dictionary<Tuple<int, int>, char>();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            Dictionary<Tuple<int, int>, char> infectedList = BuildInfectedListPart2(input);


            int x = 0;
            int y = 0;
            int orientation = 1;

            int counter = 10000000;
            int infectionCount = 0;

            for (int i = 0; i < counter; i++)
            {
                Tuple<int,int> currentPoint = new Tuple<int,int>(x, y);

                if(infectedList.ContainsKey(currentPoint))
                {
                    if(infectedList[currentPoint] == '#')
                    {
                        // Infected
                        // Turn right
                        orientation = TurnRight(orientation);
                        // Flag value
                        infectedList[currentPoint] = 'F';

                    }
                    else if (infectedList[currentPoint] == 'W')
                    {
                        // Weakened -- doesn't turn
                        // Infect value
                        infectedList[currentPoint] = '#';
                        infectionCount++;
                    }
                    else if (infectedList[currentPoint] == 'F')
                    {
                        // Flagged value - Reverse direction
                        orientation = TurnLeft(orientation);
                        orientation = TurnLeft(orientation);

                        infectedList.Remove(currentPoint);
                    }
                    else
                    {
                        throw new Exception("Unexpected value in infected list");
                    }
                }
                else
                {
                    orientation = TurnLeft(orientation);

                    infectedList.Add(currentPoint, 'W');
                }

                // Move forward
                if (orientation == 1)
                {
                    x--;
                }
                else if (orientation == 2)
                {
                    y++;
                }
                else if (orientation == 3)
                {
                    x++;
                }
                else
                {
                    y--;
                }
            }

            Console.WriteLine("Infection Count: " + infectionCount);
        }

        private static int TurnRight(int currentOrientation)
        {
            currentOrientation++;
            if (currentOrientation > 4)
                return 1;
            else
                return currentOrientation;
        }

        private static int TurnLeft(int currentOrientation)
        {
            currentOrientation--;
            if (currentOrientation <= 0)
                return 4;
            else
                return currentOrientation;
        }

        private static List<Point> BuildInfectedList(string[] input)
        {
            List<Point> infectedList = new List<Point>();

            int startingX = ((input[0].Count() - 1) / 2) * -1;
            int startingY = ((input.Count() - 1) / 2) * -1;

            for (int i = 0; i < input[0].Count(); i++)
            {
                int x = startingX;
                int y = startingY;
                char[] splitString = input[i].ToCharArray();

                for (int j = 0; j < splitString.Count(); j++)
                {
                    if (splitString[j] == '#')
                        infectedList.Add(new Point(x, y));
                    y++;
                }

                startingX++;

            }


            return infectedList;

        }
        private static Dictionary<Tuple<int,int>, char> BuildInfectedListPart2(string[] input)
        {
            Dictionary<Tuple<int, int>, char> infectedList = new Dictionary<Tuple<int, int>, char>();

            int startingX = ((input[0].Count() - 1) / 2) * -1;
            int startingY = ((input.Count() - 1) / 2) * -1;

            for (int i = 0; i < input[0].Count(); i++)
            {
                int x = startingX;
                int y = startingY;
                char[] splitString = input[i].ToCharArray();

                for (int j = 0; j < splitString.Count(); j++)
                {
                    if (splitString[j] == '#')
                        infectedList.Add(new Tuple<int,int>(x, y), '#');
                    y++;
                }

                startingX++;

            }


            return infectedList;

        }
    }
}
