using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    class Day6
    {
        public static void Run()
        {
            // Read Input File
            string lines = System.IO.File.ReadAllText(@"..\..\Inputs\\Day6.txt");

            Part2(Part1(lines));

        }

        private static List<int> Part1(string lines)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            // Initialize data baaaaaai
            string[] split = lines.Split(' ');
            List<int> memory = GetIntCollection(split);

            // Create collection of previous states
            List<string> previousIterations = new List<string>();
            previousIterations.Add(TransformToString(memory));

            // Are we still moving aboout?
            bool processing = true;

            // Some vars I'll use
            int valueToDeposit = 0;
            int leftOver = 0;
            int count = 0;

            do
            {

                int maxIndex = memory.IndexOf(memory.Max());   // Get the index of the max value
                int value = memory[maxIndex];                  // Get the value too


                // Determine deposit values (probably a nicer way of calculating this -- too tired to care!)
                if (value >= (memory.Count() - 1))
                {
                    valueToDeposit = value / (memory.Count() - 1);
                    leftOver = value - (valueToDeposit * (memory.Count() - 1));
                }
                else
                {
                    valueToDeposit = 1;
                    leftOver = 0;
                }

                // Add the left over piece to the memory block we are processing
                memory[maxIndex] = (memory[maxIndex]* 0)+leftOver;

                // Redistribute the memory
                for (int i = (value-leftOver); i > 0; i-=valueToDeposit)
                {
                    if ((maxIndex + 1) >= memory.Count())
                        maxIndex = 0;
                    else
                        maxIndex += 1;

                    memory[maxIndex] += valueToDeposit;
                }

                // If we have already seen the landing state then lets break from our loop
                if (previousIterations.Contains(TransformToString(memory)))
                    processing = false;
                else
                    previousIterations.Add(TransformToString(memory));


                // Increment count
                count++;

            }
            while (processing);

            Console.WriteLine("Count: " + count);

            return memory;

        }

        private static void Part2(List<int> memory)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            // Create collection of previous states
            List<string> previousIterations = new List<string>();
            previousIterations.Add(TransformToString(memory));

            // Are we still moving aboout?
            bool processing = true;

            // Some vars I'll use
            int valueToDeposit = 0;
            int leftOver = 0;
            int count = 0;

            do
            {

                int maxIndex = memory.IndexOf(memory.Max());   // Get the index of the max value
                int value = memory[maxIndex];                  // Get the value too


                // Determine deposit values (probably a nicer way of calculating this -- too tired to care!)
                if (value >= (memory.Count() - 1))
                {
                    valueToDeposit = value / (memory.Count() - 1);
                    leftOver = value - (valueToDeposit * (memory.Count() - 1));
                }
                else
                {
                    valueToDeposit = 1;
                    leftOver = 0;
                }

                // Add the left over piece
                memory[maxIndex] = (memory[maxIndex] * 0) + leftOver;

                // Redistribute the memory
                for (int i = (value - leftOver); i > 0; i -= valueToDeposit)
                {
                    if ((maxIndex + 1) >= memory.Count())
                        maxIndex = 0;
                    else
                        maxIndex += 1;

                    memory[maxIndex] += valueToDeposit;
                }

                // Have we seen our starting state before?
                if (previousIterations.Contains(TransformToString(memory)))
                    processing = false;


                // Increment count
                count++;

            }
            while (processing);

            Console.WriteLine("Count: " + count);
        }


        private static List<int> GetIntCollection(string[] input)
        {
            List<int> output = new List<int>();

            foreach (string s in input)
            {
                output.Add(Int32.Parse(s));
            }

            return output;
        }

        private static string TransformToString(List<int> input)
        {
            StringBuilder sb = new StringBuilder();

            foreach (int i in input)
            {
                sb.Append(i + ",");
            }

            return sb.ToString();
        }

    }
}
