using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TobogganTrajectory.Tests
{
    [TestClass]
    public class TreeCheckerTests
    {
        [TestMethod]
        public void TreeCheckerTest()
        {
            var lines = File.ReadLines(Program.InputTxt).ToList();

            new TreeChecker(lines).CheckForSlope(1, 3).Should().Be(294);
        }


        [TestMethod]
        public void TreeCheckerBonusTest()
        {
            var lines = File.ReadLines(Program.InputTxt).ToList();

            Program.SlopesBonus.Select(x => new TreeChecker(lines).CheckForSlope(x.Item1, x.Item2)).Aggregate((x, y) => x * y).Should().Be(5774564250);
        }
    }
}