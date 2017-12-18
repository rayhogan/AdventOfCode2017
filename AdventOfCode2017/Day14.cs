﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    class Day14
    {
        public static void Run()
        {
            // Read Input File
            string lines = System.IO.File.ReadAllText(@"..\..\Inputs\\Day14.txt");

            Part1(lines);
            Part2(lines);

            //Console.WriteLine(hex2binary("1"));
        }

        private static void Part1(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            // Var to hold number of used spaces
            int count = 0;

            for (int i = 0; i <= 127; i++)
            {
                string knotHash = ComputeKnotHash(input + "-" + i);

                count += CalulcateUsedSquares(knotHash);
            }

            Console.WriteLine("Used Spaces: " + count);

        }

        private static void Part2(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;
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
                if (i < 10)
                    sb.Append(0 + "" + i);
                else
                    sb.Append(i.ToString("X"));

            }

            return sb.ToString().ToLower();
        }

        private static string ComputeKnotHash(string input)
        {
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
            return HexString(xorResults);
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

        public static int[] GetIntArray(int size)
        {
            int[] output = new int[size];
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = i;
            }
            return output;
        }

        private static string hex2binary(string hexvalue)
        {
            string binaryval = "";
            binaryval = Convert.ToString(Convert.ToInt32(hexvalue, 16), 2);

            StringBuilder sb = new StringBuilder(); 

            for(int i=binaryval.Count();i<4;i++)
            {
                sb.Append("0");
            }

            sb.Append(binaryval);
            return sb.ToString();
        }

        private static int CalulcateUsedSquares(string input)
        {
            int count = 0;

            foreach (char c in input.ToCharArray())
            {
                string result = hex2binary(c.ToString());

                foreach (char ch in result.ToCharArray())
                {
                    if (ch.Equals('1'))
                        count++;
                }

            }
            return count;

        }

        private static 
    }
}


