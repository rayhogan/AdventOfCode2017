using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2017;

namespace AoCTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ScoreChecker()
        {
            Assert.AreEqual(Day9.CalculateScores(Day9.RemoveCrap("{}")), 1);
            Assert.AreEqual(Day9.CalculateScores(Day9.RemoveCrap("{{{}}}")), 6);
            Assert.AreEqual(Day9.CalculateScores(Day9.RemoveCrap("{{},{}}")), 5);
            Assert.AreEqual(Day9.CalculateScores(Day9.RemoveCrap("{{{},{},{{}}}}")), 16);
            Assert.AreEqual(Day9.CalculateScores(Day9.RemoveCrap("{<a>,<a>,<a>,<a>}")), 1);
            Assert.AreEqual(Day9.CalculateScores(Day9.RemoveCrap("{{<ab>},{<ab>},{<ab>},{<ab>}}")), 9);
            Assert.AreEqual(Day9.CalculateScores(Day9.RemoveCrap("{{<!!>},{<!!>},{<!!>},{<!!>}}")), 9);
            Assert.AreEqual(Day9.CalculateScores(Day9.RemoveCrap("{{<a!>},{<a!>},{<a!>},{<ab>}}")), 3);
        }

        [TestMethod]
        public void GarbageCounter()
        {
            Assert.AreEqual(Day9.CountGarbageCharacters(Day9.RemoveCancelledCharacters("<>")), 0);
            Assert.AreEqual(Day9.CountGarbageCharacters(Day9.RemoveCancelledCharacters("<random characters>")), 17);
            Assert.AreEqual(Day9.CountGarbageCharacters(Day9.RemoveCancelledCharacters("<<<<>")), 3);
            Assert.AreEqual(Day9.CountGarbageCharacters(Day9.RemoveCancelledCharacters("<{!>}>")), 2);
            Assert.AreEqual(Day9.CountGarbageCharacters(Day9.RemoveCancelledCharacters("<!!>")), 0);
            Assert.AreEqual(Day9.CountGarbageCharacters(Day9.RemoveCancelledCharacters("<!!!>>")), 0);
            Assert.AreEqual(Day9.CountGarbageCharacters(Day9.RemoveCancelledCharacters("<{o\"i!a,<{i<a>")), 10);
        }
    }
}
