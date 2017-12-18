using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2017.Stuff;

namespace AdventOfCode2017
{
    class Day13
    {
        public static void Run()
        {
            // Read Input File
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\\Day13.txt");

            Part1(lines);
            Part2(lines);

        }

        private static void Part1(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            List<FirewallLayer> firewall = InitializeFirewall(input);

            int currentPosition = -1;
            int sum = 0;

            foreach (FirewallLayer fl in firewall)
            {
                // Increment your position
                currentPosition++;

                if (firewall[currentPosition].Position.Equals(0) && !firewall[currentPosition].EmptyLayer)
                {
                    sum += (currentPosition * (firewall[currentPosition].Range + 1));
                }

                foreach (FirewallLayer fw in firewall)
                {
                    fw.MoveScanner();
                }
            }

            Console.WriteLine("Severity: " + sum);

        }

        private static void Part2(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            List<FirewallLayer> firewall = InitializeFirewall(input);

            bool computing = true;
            int count = 0;
            for (int i = 0; computing; i++)
            {
                computing = false;
                for (int j = 0; j < firewall.Count; j++)
                {
                    if (!firewall[j].EmptyLayer)
                    {

                        if ((i + j) % (2 * firewall[j].Range) == 0)
                        {
                            computing = true;
                            break;
                        }

                    }
                }
                count = i;
            }

            Console.WriteLine("Wait Time: " + count);
        }


        private static List<FirewallLayer> InitializeFirewall(string[] input)
        {
            List<FirewallLayer> firewall = new List<FirewallLayer>();
            Dictionary<int, int> data = new Dictionary<int, int>();

            foreach (string s in input)
            {
                string[] split = s.Split(':');

                data.Add(Int32.Parse(split[0]), Int32.Parse(split[1].ToString()));
            }

            for (int i = 0; i <= data.Last().Key; i++)
            {
                if (!data.ContainsKey(i))
                {
                    firewall.Add(new FirewallLayer(0, 0, true));
                }
                else
                {

                    firewall.Add(new FirewallLayer(0, data[i] - 1, true));
                }

            }

            return firewall;
        }
    }
}
