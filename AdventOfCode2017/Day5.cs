using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    class Day5
    {
        public static void Run()
        {
            // Read Input File
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\\Day5.txt");
            Part1(lines);
            Part2(lines);
        }

        private static void Part1(string[] lines)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            List<int> input = BuildDataList(lines);

            int currentPosition = 0;    // Current position of our data list
            bool outOfBounds = false;   // Are we out of bounds
            int count = 0;              // Counts / steps

            // While still in bounds
            while (!outOfBounds)
            {

                int lookingAt = currentPosition;              // What position are we looking at
                currentPosition += input[currentPosition];    // Increase next position by the value of data in list
                input[lookingAt] = input[lookingAt] + 1;      // Increase the value we are looking at by 1

                count++;                                      // Increment our steps count

                // Check if we are still in bounds for the next iteration
                if (currentPosition > (input.Count - 1) || currentPosition < 0)
                    outOfBounds = true;
            }

            // Print steps
            Console.WriteLine("Count: " + count);

        }
        private static void Part2(string[] lines)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            List<int> input = BuildDataList(lines);

            int currentPosition = 0;    // Current position of our data list
            bool outOfBounds = false;   // Are we out of bounds
            int count = 0;              // Counts / steps

            while (!outOfBounds)
            {
                int lookingAt = currentPosition;              // What position are we looking at
                currentPosition += input[currentPosition];    // Increae next position by the value of data in list

                // If the value we are looking at is greater or equal to three
                if (input[lookingAt] >= 3)
                    input[lookingAt] = input[lookingAt] - 1; // Then decrease value by 1
                else
                    input[lookingAt] = input[lookingAt] + 1; // Or incrememnt by 1

                count++;                                      // Increment our steps count

                // Check if we are still in bounds for the next iteration
                if (currentPosition > (input.Count - 1) || currentPosition < 0)
                    outOfBounds = true;
            }

            Console.WriteLine("Count: " + count);
        }

        private static List<int> BuildDataList(string[] input)
        {
            List<int> output = new List<int>();

            foreach (string s in input)
            {
                output.Add(Int32.Parse(s));
            }

            return output;
        }
    }
}
