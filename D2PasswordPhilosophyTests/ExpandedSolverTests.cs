using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using FluentAssertions;

namespace PasswordPhilosophy.Tests
{
    [TestClass()]
    public class ExpandedSolverTests
    {
        [TestMethod]
        public void CheckMinMaxTest()
        {
            var strings = File.ReadLines(Program.InputTxt).ToList();

            new ExpandedSolver(new IsBetweenMinAndMaxStrategy()).CountValidForRule(strings).Should().Be(454);
        }

        [TestMethod]
        public void CheckPositionTest()
        {
            var strings = File.ReadLines(Program.InputTxt).ToList();

            new ExpandedSolver(new IsInPosition1XOrPosition2Strategy()).CountValidForRule(strings).Should().Be(649);
        }
    }
}