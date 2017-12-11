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

                        clipboard.Add(new Tuple<int, int>(pos, data[pos]));

                        if (pos + 1 > data.Length - 1)
                            pos = 0;
                        else
                            pos++;
                    }


                    // Swap them about now
                    for (int i = 0; i < indexes.Count; i++)
                    {
                        data[indexes[(indexes.Count - 1) - i]] = clipboard[i].Item2;
                    }


                }

                position = position + processing + skipSize;
                skipSize++;

                while (position >= data.Length)
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

            List<int> transformed = TransformToASCII(input);
            //17, 31, 73, 47, 23
            transformed.Add(17);
            transformed.Add(31);
            transformed.Add(73);
            transformed.Add(47);
            transformed.Add(23);

            int skipSize = 0;
            int position = 0;

            List<Tuple<int, int>> clipboard = new List<Tuple<int, int>>();

            int[] data = GetIntArray(256);

            for (int iCount = 0; iCount < 64; iCount++)
            {
                foreach (int inty in transformed)
                {
                    int processing = inty;

                    if (processing > 1)
                    {
                        List<int> indexes = new List<int>();

                        int pos = position;
                        for (int i = 0; i < processing; i++)
                        {
                            indexes.Add(pos);

                            clipboard.Add(new Tuple<int, int>(pos, data[pos]));

                            if (pos + 1 > data.Length - 1)
                                pos = 0;
                            else
                                pos++;
                        }


                        // Swap them about now
                        for (int i = 0; i < indexes.Count; i++)
                        {
                            data[indexes[(indexes.Count - 1) - i]] = clipboard[i].Item2;
                        }


                    }

                    position = position + processing + skipSize;
                    skipSize++;

                    while (position >= data.Length)
                    {
                        position = position - data.Length;
                    }


                    clipboard.Clear();

                }
            }



            List<int> xorResults = XOROperations(data);
            Console.WriteLine("Hex: " + HexString(xorResults));



        }

        public static int[] GetIntArray(int size)
        {
            int[] output = new int[size];
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = i;
            }
            return output;
        }

        public static List<int> TransformToASCII(string input)
        {
            List<int> output = new List<int>();

            char[] split = input.ToCharArray();
            foreach (char c in split)
            {
                int unicode = c;
                output.Add(unicode);
            }

            return output;
        }

        public static string HexString(List<int> input)
        {
            StringBuilder sb = new StringBuilder();

            foreach (int i in input)
            {
                if(i<10)                
                    sb.Append(0 +""+ i);                
                else
                    sb.Append(i.ToString("X"));

                Console.WriteLine("Value: " + i + " becomes " + i.ToString("X"));
            }

            return sb.ToString().ToLower();
        }

        public static List<int> XOROperations(int[] data)
        {
            List<int> output = new List<int>();

            for (int i = 0; i < data.Length; i += 16)
            {
                output.Add(data[i] ^ data[i + 1] ^ data[i + 2] ^ data[i + 3] ^ data[i + 4] ^ data[i + 5] ^ data[i + 6] ^ data[i + 7] ^ data[i + 8] ^ data[i + 9] ^ data[i + 10] ^ data[i + 11] ^ data[i + 12] ^ data[i + 13] ^ data[i + 14] ^ data[i + 15]);

            }

            return output;
        }
    }
}