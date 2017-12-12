using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2017.Stuff;

namespace AdventOfCode2017
{
    class Day12
    {
        public static void Run()
        {
            // Read Input File
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\\Day12.txt");

            Part1(lines);
            Part2(lines);

        }

        // Some collections for tracking shiiizzzz
        private static Dictionary<string, string[]> lookup;
        private static List<string> hops = new List<string>();

        private static void Part1(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            // Build the lookup
            lookup = BuildRelationshipLookup(input);

            // Find the connections recursively
            FindConnections("0");

            Console.WriteLine("Connections to 0: " + hops.Count);
        }

        private static void Part2(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            int count = 0;

            while(lookup.Count > 0)
            {
                FindConnections(lookup.First().Key);

                foreach(string s in hops)
                {
                    if(lookup.ContainsKey(s.Trim()))
                        lookup.Remove(s.Trim());
                }

                count++;
            }

            Console.WriteLine("No of Groups: " + count);
        }

       
        private static void FindConnections(string startingProgram)
        {
            startingProgram = startingProgram.Trim();

            hops.Add(startingProgram);

            foreach (string s in lookup[startingProgram])
            {
                if (!hops.Contains(s.Trim()))
                {
                    FindConnections(s);
                }
            }


        }

        private static Dictionary<string, string[]> BuildRelationshipLookup(string[] input)
        {
            Dictionary<string, string[]> output = new Dictionary<string, string[]>();

            foreach (string s in input)
            {
                string[] split1 = s.Split('<');
                string[] split2 = s.Split('>');
                string[] split3 = split2[1].Split(',');

                output.Add(split1[0].Trim(), split3);

            }


            return output;

        }
    }
}
