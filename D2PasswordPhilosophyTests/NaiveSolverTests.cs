using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordPhilosophy.Tests
{
    [TestClass]
    public class NaiveSolverTests
    {
        [TestMethod]
        public void CheckMinMaxTest()
        {
            var strings = File.ReadLines(Program.InputTxt).ToList();

            new NaiveSolver(strings).CheckMinMax().Should().Be(454);
        }

        [TestMethod]
        public void CheckPositionTest()
        {
            var strings = File.ReadLines(Program.InputTxt).ToList();

            new NaiveSolver(strings).CheckPosition().Should().Be(649);
        }
    }
}