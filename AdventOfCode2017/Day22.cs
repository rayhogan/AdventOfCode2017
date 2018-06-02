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
            //Part2(lines);
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

            for(int i=0;i<counter; i++)
            {
                //Console.WriteLine(x + "," + y);
                if (workingList.Contains(new Point(x,y)))
                {
                    // Currently infected

                    //Turn Right -- calculate new orientation
                    int orient = (int)orientation;
                    orient++;
                    if(orient >= 5) { orient = 1; }
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
                if(orientation == Orientation.North)
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

            Console.WriteLine("Infection Count: "+infectionCount);
        }

        private static void Part2(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static List<Point> BuildInfectedList(string[] input)
        {
            List<Point> infectedList = new List<Point>();

            int startingX = ((input[0].Count() -1 )/ 2) * -1;
            int startingY = ((input.Count() - 1) / 2) * -1;

            for(int i=0;i<input[0].Count();i++)
            {
                int x = startingX;
                int y = startingY;
                char[] splitString = input[i].ToCharArray();

                for(int j=0;j<splitString.Count();j++)
                {
                    if (splitString[j] == '#')
                        infectedList.Add(new Point(x, y));
                    y++;
                }

                startingX++;

            }


            return infectedList;

        }
    }
}
