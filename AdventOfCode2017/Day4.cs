using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    class Day4
    {

        public static void Run()
        {
            // Read Input File
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\\Day4.txt");
            Part1(lines);
            Part2(lines);
        }

        private static void Part1(string[] lines)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            // Count of valid passphrases
            int count = 0;

            foreach(string s in lines)
            {
                // Split in array of strings
                string[] words = s.Split(' ');

                // Check if duplicates by comparing the length of original
                // aaray against a count of how many distinct entries there are.
                if (words.Length == words.Distinct().Count())
                    count++;

            }

            Console.WriteLine("Valid Passphrases: " + count);
        }

        private static void Part2(string[] lines)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            // Count of valid passphrases
            int count = 0;

            foreach (string s in lines)
            {
                // Split in array of strings
                string[] words = s.Split(' ');

                // Rearrange each word alphabetically
                for(int i= 0;i < words.Length;i++)
                {
                    words[i] = String.Concat(words[i].OrderBy(c => c));
                }

                // Check if duplicates by comparing the length of original
                // aaray against a count of how many distinct entries there are.
                if (words.Length == words.Distinct().Count())
                    count++;

            }

            Console.WriteLine("Valid Passphrases: " + count);
        }
    }
}
