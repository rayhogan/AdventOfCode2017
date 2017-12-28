using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2017.Stuff;

namespace AdventOfCode2017
{
    class Day16
    {
        public static void Run()
        {
            // Read Input File
            string line = System.IO.File.ReadAllText(@"..\..\Inputs\\Day16.txt");

            Part1(line);
            Part2(line);
        }

        private static void Part1(string lines)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            DanceCoordinator dc = new DanceCoordinator(new char[] { 'a','b','c','d','e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p' } );

            string[] splitCommands = lines.Split(',');

            foreach(string s in splitCommands)
            {
                dc.ProcessCommand(s);
            }

            Console.WriteLine(dc.PrintOrder());


        }

        private static void Part2(string lines)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            DanceCoordinator dc = new DanceCoordinator(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p' });
            string[] splitCommands = lines.Split(',');

            bool searching = true;
            int count = 0;
            do
            {
                count++;
                foreach (string s in splitCommands)
                {
                    dc.ProcessCommand(s);
                }

                if (dc.PrintOrder().Equals("abcdefghijklmnop"))
                    searching = false;
            }
            while (searching);

            int iterations = 1000000000 % count;

            for (int i=0;i<iterations;i++)
            {
                foreach (string s in splitCommands)
                {
                    dc.ProcessCommand(s);
                }

            }           

            Console.WriteLine(dc.PrintOrder());
        }
    }
}
