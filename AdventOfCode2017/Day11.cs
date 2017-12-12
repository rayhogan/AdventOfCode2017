using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2017.Stuff;

namespace AdventOfCode2017
{
    public class Day11
    {
        public static void Run()
        {
            // Read Input File
            string lines = System.IO.File.ReadAllText(@"..\..\Inputs\\Day11.txt");

            Part1(lines);
            Part2(lines);
        }

        private static void Part1(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            Hexagon position = GetHexPosition(input);

            int steps = CalculateShortestSteps(new Hexagon(0, 0, 0), position);

            Console.WriteLine("Shortest Steps: " + steps);


        }

        private static void Part2(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            Hexagon position = GetHexPosition(input);

            int furthest = GetFurthestPosition(input);

            Console.WriteLine("Shortest Steps: " + furthest);
        }


        public static Hexagon GetHexPosition(string input)
        {
            // Hex starting position
            Hexagon hex = new Hexagon(0, 0, 0);

            foreach (string s in input.Split(','))
            {
                switch (s)
                {
                    case "n":
                        hex.Y--;
                        hex.X++;
                        break;
                    case "s":
                        hex.Y++;
                        hex.X--;
                        break;
                    case "ne":
                        hex.X++;
                        hex.Z--;
                        break;
                    case "nw":
                        hex.Y--;
                        hex.Z++;
                        break;
                    case "se":
                        hex.Y++;
                        hex.Z--;
                        break;
                    case "sw":
                        hex.X--;
                        hex.Z++;
                        break;
                    default:
                        Console.WriteLine("Unknown input");
                        break;
                }
            }

            return hex;
        }

        public static int CalculateShortestSteps(Hexagon a, Hexagon b)
        {

            return (Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y) + Math.Abs(a.Z - b.Z)) / 2;
        }


        public static int GetFurthestPosition(string input)
        {
            // Hex starting position
            Hexagon hex = new Hexagon(0, 0, 0);

            List<int> stepsAway = new List<int>();

            foreach (string s in input.Split(','))
            {
                switch (s)
                {
                    case "n":
                        hex.Y--;
                        hex.X++;
                        break;
                    case "s":
                        hex.Y++;
                        hex.X--;
                        break;
                    case "ne":
                        hex.X++;
                        hex.Z--;
                        break;
                    case "nw":
                        hex.Y--;
                        hex.Z++;
                        break;
                    case "se":
                        hex.Y++;
                        hex.Z--;
                        break;
                    case "sw":
                        hex.X--;
                        hex.Z++;
                        break;
                    default:
                        Console.WriteLine("Unknown input");
                        break;
                }

                stepsAway.Add(CalculateShortestSteps(new Hexagon(0, 0, 0), hex));
            }

            return stepsAway.Max();
        }
    }
}
