using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    class Day1
    {
        public static void Run()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;
            // Read Input File
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\\Day1.txt");

            // Sum
            int sum = 0;

            for (int i = 0; i < (lines[0].Length - 1); i++)
            {
                if (lines[0].ToCharArray()[i].Equals(lines[0].ToCharArray()[i + 1]))
                {
                    sum += Int32.Parse(lines[0].ToCharArray()[i].ToString());
                }
            }

            // Check first & last
            if (lines[0].ToCharArray()[0].Equals(lines[0].ToCharArray()[lines[0].Length - 1]))
            {
                sum += Int32.Parse(lines[0].ToCharArray()[0].ToString());
            }


            // Print result
            Console.WriteLine("Sum: " + sum);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            // Reset Sum
            sum = 0;
            int location = 0;

            for (int i = 0; i < lines[0].Length; i++)
            {
                location = (lines[0].Length / 2) + i;

                if (location > (lines[0].Length - 1))
                    location = location - lines[0].Length;

                if (lines[0].ToCharArray()[i].Equals(lines[0].ToCharArray()[location]))
                {
                    sum += Int32.Parse(lines[0].ToCharArray()[i].ToString());
                }
            }

            // Print result
            Console.WriteLine("Sum: " + sum);

        }
    }
}
