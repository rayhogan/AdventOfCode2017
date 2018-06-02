using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2017.Stuff;

namespace AdventOfCode2017
{
    class Day21
    {
        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\\Day21.txt");

            List<string> test = new List<string>();

            test.Add("Theworld");

            Console.WriteLine(test.Contains("The"));
                
            Part1(lines);
            Part2(lines);
        }

        private static void Part1(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            ImageProcessor image = new ImageProcessor(input);


            for(int i=0;i<5;i++)
            {
                image.Mutate();
            }

           //image.Draw();


            Console.WriteLine("On: " + image.CountLights());

        }

        private static void Part2(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            ImageProcessor image = new ImageProcessor(input);


            for (int i = 0; i < 18; i++)
            {
                image.Mutate();
            }

            //image.Draw();


            Console.WriteLine("On: " + image.CountLights());
        }

    }
}
