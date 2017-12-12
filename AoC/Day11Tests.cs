using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2017;
using AdventOfCode2017.Stuff;

namespace AoC
{
    [TestClass]
    public class Day11Tests
    {

        [TestMethod]
        public void CalculateStepsTets()
        {
            string input = "ne,ne,ne";

            Hexagon hex = Day11.GetHexPosition(input);

            int steps = Day11.CalculateShortestSteps(new Hexagon(0, 0, 0), hex);

            Assert.AreEqual(steps, 3);

        }
    }
}
