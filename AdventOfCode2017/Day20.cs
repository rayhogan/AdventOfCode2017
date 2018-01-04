using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2017.Stuff;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCode2017
{
    class Day20
    {
        public static void Run()
        {
            // Read Input File
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\\Day20.txt");

            Part1(lines);
            Part2(lines);

        }

        private static void Part1(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            List<Particle> particles = BuildDataStructure(input);

            int ticks = 1000;

            for (int i = 0; i < ticks; i++)
            {
                foreach (Particle p in particles)
                {
                    p.PerformCalculations();
                }
            }

            int index = 0;
            int value = Int32.MaxValue;

            for (int i = 0; i < particles.Count; i++)
            {
                if (particles[i].GetDistance() < value)
                {
                    value = particles[i].GetDistance();
                    index = i;
                }
            }

            Console.WriteLine("Closest particle after " + ticks + " ticks: " + index);
        }

        private static void Part2(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            List<Particle> particles = BuildDataStructure(input);

            int ticks = 1000;

            for (int i = 0; i < ticks; i++)
            {
                List<string> positions = new List<string>();

                foreach (Particle p in particles)
                {
                    p.PerformCalculations();
                    positions.Add(p.GetPosition());
                }

                var duplicates = positions.Select((text, ind) => new { Index = ind, Text = text }).GroupBy(g => g.Text).Where(g => g.Count() > 1);

                List<Particle> particlesToRemove = new List<Particle>();
                foreach(var group in duplicates)
                {
                    foreach(var g in group)
                    {
                        particlesToRemove.Add(particles[g.Index]);
                    }
                }
                
                foreach (Particle p in particlesToRemove)
                {
                    
                    particles.Remove(p);
                }                
                
            }


            Console.WriteLine("Particles left after collisions: " + particles.Count());
        }

        private static List<Particle> BuildDataStructure(string[] input)
        {
            List<Particle> output = new List<Particle>();

            foreach (string s in input)
            {

                List<ParticleProperty> properties = new List<ParticleProperty>();

                string removeCharacters = Regex.Replace(s, "[^-.0-9]", " ");
                string[] split = removeCharacters.Split(' ');

                List<int> integers = new List<int>();

                foreach (string number in split)
                {
                    if (number != string.Empty)
                    {
                        integers.Add(Convert.ToInt32(number));
                    }
                }

                if (integers.Count != 9)
                    throw new Exception("ERROR PARSING INTS FROM INPUT");
                else
                {
                    properties.Add(new ParticleProperty(integers[0], integers[1], integers[2])); // Position
                    properties.Add(new ParticleProperty(integers[3], integers[4], integers[5])); // Velocity
                    properties.Add(new ParticleProperty(integers[6], integers[7], integers[8])); // Acceleration
                }

                output.Add(new Particle(properties[0], properties[1], properties[2]));
            }

            return output;
        }
    }
}
