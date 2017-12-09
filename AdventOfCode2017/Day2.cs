using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    class Day2
    {
        public static void Run()
        {
            // Read Input File
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\\Day2.txt");

            Part1(lines);
            Part2(lines);

        }

        private static void Part1(string[] lines)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            int sum = 0;

            foreach (string s in lines)
            {
                int high = 0;
                int low = Int32.MaxValue;
                string[] values = s.Split(' ');

                foreach (string split in values)
                {
                    if (Int32.Parse(split) > high)
                        high = Int32.Parse(split);

                    if (Int32.Parse(split) < low)
                        low = Int32.Parse(split);
                }

                sum += (high - low);
            }

            Console.WriteLine("Sum: " + sum);
        }

        private static void Part2(string[] lines)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            int sum = 0;

            foreach (string s in lines)
            {
                string[] values = s.Split(' ');

                foreach (string split in values)
                {
                    foreach (string split2 in values)
                    {
                        if (Int32.Parse(split) % Int32.Parse(split2) == 0 && !split.Equals(split2))
                        {
                            sum += (Int32.Parse(split) / Int32.Parse(split2));
                        }
                    }
                }
            }

            Console.WriteLine("Sum: " + sum);
        }
    }
}
