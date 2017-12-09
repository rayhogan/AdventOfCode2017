using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2017.Stuff;

namespace AdventOfCode2017
{
    class Day7
    {
        public static void Run()
        {
            // Read Input File
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\\Day7.txt");

            string root = Part1(lines);
            Part2(lines, root);
        }

        private static string Part1(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            // Filter down array to only items that contain ->
            var filtered = input.Where(entries => entries.Contains("->"));

            List<string> notAtBottom = new List<string>();
            List<string> potentiallyAtBottom = new List<string>();

            // Loop through the input and separate the value into two
            // collections - one containing items that are definitiely not the root node
            // and one contain items that could be the root node
            foreach (string s in filtered)
            {
                string[] split = s.Split('>');
                string[] split2 = s.Split('(');

                foreach (string notBottoms in split[1].Split(','))
                {
                    notAtBottom.Add(notBottoms.Trim());
                }

                potentiallyAtBottom.Add(split2[0].Trim());
            }

            // Loop through the collections to find the root node
            bool foundRootNode = false;
            string root = "";
            while (!foundRootNode)
            {
                foreach (string s in potentiallyAtBottom)
                {
                    if (!notAtBottom.Contains(s))
                    {
                        foundRootNode = true;
                        root = s;
                        break;
                    }
                }
            }

            Console.WriteLine("Root Node: " + root);

            return root;

        }

        private static Dictionary<string, int> towers;
        private static Dictionary<string, string[]> graph;

        private static void Part2(string[] input, string rootnode)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            towers = new Dictionary<string, int>();

            foreach (string s in input)
            {
                string[] split = s.Split('(');

                towers.Add(split[0].Trim(), Int32.Parse(split[1].Split(')')[0]));
            }

            // Towers that are holding stuff
            var filtered = input.Where(entries => entries.Contains("->"));

            graph = new Dictionary<string, string[]>();

            foreach (string s in filtered)
            {
                string[] split = s.Split('>');
                string[] split2 = s.Split('(');

                graph.Add(split2[0].Trim(), split[1].Split(','));

            }

            // Construct tree structre of towers
            Tower structure = BuildTree(rootnode);


            List<int> weights = new List<int>();
            foreach (Tower t in structure.GetChildrenNodes())
            {
                weights.Add(t.CalculateTotalWeight());
                
            }

            var distinctValue = weights.GroupBy(i => i)
                    .Where(g => g.Count() == 1)
                    .Select(g => g.Key);

            // Find the anomaly
            structure.FindAnomaly(weights.First()-distinctValue.First());


        }

        private static Tower BuildTree(string startingNode)
        {
            Tower tower = new Tower(startingNode.Trim(), towers[startingNode.Trim()]);

            if (graph.ContainsKey(startingNode.Trim()))
            {
                foreach (string s in graph[startingNode.Trim()])
                {
                    tower.AddChild(BuildTree(s.Trim()));
                }
            }

            return tower;
        }


    }
}
