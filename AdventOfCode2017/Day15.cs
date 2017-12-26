using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    class Day15
    {
        public static int multiplierA = 16807;
        public static int multiplierB = 48271;
        public static int divider = 2147483647;
        public static void Run()
        {
            //Part1(618, 814);
            Part2(618, 814);
        }

        private static void Part1(long generatorA, long generatorB)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            //generatorA = 65;
            //generatorB = 8921;

            int count = 0;

            for (int i = 0; i < 40000000; i++)
            {

                generatorA = (generatorA * multiplierA) % divider;
                generatorB = (generatorB * multiplierB) % divider;



                if (MatchingBinaryStubs(Convert.ToString(generatorA, 2), Convert.ToString(generatorB, 2)))
                {
                    count++;
                }
            }

            Console.WriteLine("Matching: " + count);
        }

        private static void Part2(long generatorA, long generatorB)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            int count = 0;

            for (int i = 0; i < 5000000; i++)
            {

                do { generatorA = (generatorA * multiplierA) % divider; } while (generatorA % 4 != 0);


                do { generatorB = (generatorB * multiplierB) % divider; } while (generatorB % 8 != 0);


                if (MatchingBinaryStubs(Convert.ToString(generatorA, 2), Convert.ToString(generatorB, 2)))
                {
                    count++;

                }

            }
            Console.WriteLine("Matching: " + count);


        }

        private static bool MatchingBinaryStubs(string A, string B)
        {

            if (A.Length > 32 || B.Length > 32)
                Console.WriteLine("Something wrong");

            if (A.Length < 32)
                A = BinaryPadding(A);

            if (B.Length < 32)
                B = BinaryPadding(B);


            if (A.Substring(A.Length - 16, 16).Equals(B.Substring(B.Length - 16, 16)))
                return true;
            else
                return false;
        }

        private static string BinaryPadding(string input)
        {

            StringBuilder sb = new StringBuilder();

            while (sb.Length < (32 - input.Length))
                sb.Append("0");

            sb.Append(input);

            return sb.ToString();
        }
    }
}
