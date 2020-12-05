using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryBoarding.Tests
{
    [TestClass]
    public class SeatTests
    {
        [DataTestMethod]
        [DataRow("BFFFBBFRRR", 567)]
        [DataRow("FFFBBBFRRR", 119)]
        [DataRow("BBFFBBFRLL", 820)]
        public void GetSeatId_WhenExample(string seat, int id)
        {
            new Seat(seat).SeatId.Should().Be(id);
        }
    }
}