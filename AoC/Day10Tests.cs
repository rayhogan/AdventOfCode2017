using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2017;
using System.Collections.Generic;

namespace AoC
{
    [TestClass]
    public class Day10Tests
    {
        [TestMethod]
        public void IntArrayBuilder()
        {
            int[] testArray = Day10.GetIntArray(256);

            Assert.AreEqual(testArray.Length, 256);

            for (int i = 0; i < testArray.Length; i++)
            {
                Assert.AreEqual(testArray[i], i);
            }
        }

        [TestMethod]
        public void TransformToASCII()
        {
            List<int> output = new List<int>();
            //49,44,50,44,51
            output.Add(49);
            output.Add(44);
            output.Add(50);
            output.Add(44);
            output.Add(51);

            List<int> result = Day10.TransformToASCII("1,2,3");


            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(output[i], result[i]);
            }

        }

        [TestMethod]
        public void XORTests()
        {
            int[] input = new int[16];
            //65 ^ 27 ^ 9 ^ 1 ^ 4 ^ 3 ^ 40 ^ 50 ^ 91 ^ 7 ^ 6 ^ 0 ^ 2 ^ 5 ^ 68 ^ 22
            input[0] = 65;
            input[1] = 27;
            input[2] = 9;
            input[3] = 1;
            input[4] = 4;
            input[5] = 3;
            input[6] = 40;
            input[7] = 50;
            input[8] = 91;
            input[9] = 7;
            input[10] = 6;
            input[11] = 0;
            input[12] = 2;
            input[13] = 5;
            input[14] = 68;
            input[15] = 22;

            List<int> result = Day10.XOROperations(input);

            Assert.AreEqual(result[0], 64);
        }

        [TestMethod]
        public void End2End()
        {
            List<int> output = new List<int>();
            //49,44,50,44,51
            output.Add(49);
            output.Add(44);
            output.Add(50);
            output.Add(44);
            output.Add(51);

            List<int> result = Day10.TransformToASCII("1,2,3");


            
        }

        [TestMethod]
        public void HexConversion()
        {
            //64, 7, 255
            List<int> input = new List<int>();
            input.Add(64);
            input.Add(07);
            input.Add(255);

            string result = Day10.HexString(input);

            Assert.AreEqual(result, "4007ff");
        }

    }
}
