using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace D11SeatingSystem.Tests
{
    [TestClass]
    public class FerryOneTests
    {
        [TestMethod]
        public void PlacePeopleTest()
        {
            var strings = File.ReadLines(Program.InputTxt).ToList();
            var ferryOne = new FerryOne(strings);

            ferryOne.PlacePeople();

            ferryOne.CountOccupiedSeats().Should().Be(2277);
        }
    }
}