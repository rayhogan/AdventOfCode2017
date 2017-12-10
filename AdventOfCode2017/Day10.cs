using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public class Day10
    {
        public static void Run()
        {
            // Read Input File
            string lines = System.IO.File.ReadAllText(@"..\..\Inputs\\Day10.txt");

            Part1(lines);
            Part2(lines);
        }

        private static void Part1(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            int skipSize = 0;
            int position = 0;

            List<Tuple<int, int>> clipboard = new List<Tuple<int, int>>();

            int[] data = GetIntArray(256);

            string[] split = input.Split(',');

            foreach (int i in data)
            {
                Console.Write(i);
            }
            Console.WriteLine("");

            foreach (string s in split)
            {
                

                int processing = Int32.Parse(s);

                if (processing > 1)
                {
                    List<int> indexes = new List<int>();

                    int pos = position;
                    for (int i = 0; i < processing; i++)
                    {
                        indexes.Add(pos);

                        clipboard.Add(new Tuple<int,int>(pos, data[pos]));

                        if (pos + 1 > data.Length-1)
                            pos = 0;
                        else
                            pos++;
                    }


                    // Swap them about now
                    for(int i=0;i<indexes.Count;i++)
                    {
                        data[indexes[(indexes.Count-1)-i]] = clipboard[i].Item2;
                    }
                    
                   
                }

                position = position + processing + skipSize;
                skipSize++;

                while (position > data.Length)
                {
                    position = position - data.Length;
                }


                clipboard.Clear();

            }
            Console.WriteLine("Sum: " + (data[0] * data[1]));
        }

        private static void Part2(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static int[] GetIntArray(int size)
        {
            int[] output = new int[size];
            for(int i=0;i<output.Length;i++)
            {
                output[i] = i;
            }
            return output;
        }
    }
}
