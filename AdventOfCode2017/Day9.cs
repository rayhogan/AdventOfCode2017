using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public class Day9
    {
        public static void Run()
        {
            // Read Input File
            string lines = System.IO.File.ReadAllText(@"..\..\Inputs\\Day9.txt");

            Part1(lines);
            Part2(lines);
        }

        private static void Part1(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            input = RemoveCrap(input);

            Console.WriteLine("Score: " + CalculateScores(input));

        }

        private static void Part2(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Garbage Count: " +CountGarbageCharacters(RemoveCancelledCharacters(input)));
        }

        public static string RemoveCrap(string input)
        {
            // Convert back to string
            input = RemoveCancelledCharacters(input);

            // Remove garbage
            char opening = '<';
            char closing = '>';
            Regex regex = new Regex(string.Format("(?<={0})([^{1}]*)", opening, closing));
            input = regex.Replace(input, "");

            return input;
        }

        public static string RemoveCancelledCharacters(string input)
        {
            char[] stream = input.ToCharArray();

            // Remove any ! values
            for (int i = 0; i < stream.Length; i++)
            {
                if (stream[i].Equals('!'))
                {
                    stream[i] = '@';
                    stream[i + 1] = '@';
                }
            }
            // Return stringed result
            input = new String(stream);
            return input.Replace("@", "");
        }

        public static int CountGarbageCharacters(string input)
        {
            // Remove garbage
            char opening = '<';
            char closing = '>';
            Regex regex = new Regex(string.Format("(?<={0})([^{1}]*)", opening, closing));
            MatchCollection mc = regex.Matches(input);

            int sum = 0;
            foreach(Match s in mc)
            {
                sum += s.Length;
            }

            return sum;
        }

        public static int CalculateScores(string input)
        {
            int result = 0;
            int value = 0;
            foreach (char s in input.ToCharArray())
            {
                if (s.Equals('{'))
                {
                    value++;
                }
                else if (s.Equals('}'))
                {
                    result += value;
                    value--;
                }
            }
            return result;
        }
    }
}
