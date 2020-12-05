using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryBoarding.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("BFFFBBFRRR", 567)]
        [DataRow("FFFBBBFRRR", 119)]
        [DataRow("BBFFBBFRLL", 820)]
        public void GetSeatId_WhenExample(string seat, int id)
        {
            Program.GetSeatId(seat).Should().Be(id);
        }

        [TestMethod]
        public void MaxSeatsIdTest()
        {
            var strings = File.ReadLines(Program.InputTxt);

            var seatsId = strings.Select(Program.GetSeatId).ToList();

            seatsId.Max().Should().Be(874);
        }

        [TestMethod]
        public void GetMissingSeatIdTest()
        {
            var strings = File.ReadLines(Program.InputTxt);

            var missingSeat = Program.GetMissingSeat(strings.Select(Program.GetSeatId).ToList());

            missingSeat.Should().Be(594);
        }
    }
}