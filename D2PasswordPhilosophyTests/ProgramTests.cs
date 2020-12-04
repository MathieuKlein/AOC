using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordPhilosophy.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void CheckMinMaxTest()
        {
            var strings = File.ReadLines(Program.InputTxt).ToList();

            Program.CheckMinMax(strings).Should().Be(454);
        }

        [TestMethod]
        public void CheckPositionTest()
        {
            var strings = File.ReadLines(Program.InputTxt).ToList();

            Program.CheckPosition(strings).Should().Be(649);
        }
    }
}