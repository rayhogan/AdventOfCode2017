using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2017;

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

            for(int i=0;i<testArray.Length;i++)
            {
                Assert.AreEqual(testArray[i], i);
            }
        }
    }
}
