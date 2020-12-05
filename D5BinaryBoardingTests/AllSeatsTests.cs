using System.IO;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryBoarding.Tests
{
    [TestClass]
    public class AllSeatsTests
    {
        [TestMethod]
        public void MaxSeatsIdTest()
        {
            var strings = File.ReadLines(Program.InputTxt);

            new AllSeats(strings).MaxSeatId().Should().Be(874);
        }

        [TestMethod]
        public void GetMissingSeatIdTest()
        {
            var strings = File.ReadLines(Program.InputTxt);

            new AllSeats(strings).FindMissingSeat().Should().Be(594);
        }
    }
}