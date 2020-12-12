using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace D11SeatingSystem.Tests
{
    [TestClass]
    public class FerryTwoTests
    {
        [TestMethod]
        public void PlacePeopleTest()
        {
            var strings = File.ReadLines(Program.InputTxt).ToList();
            var ferryTwo = new FerryTwo(strings);

            ferryTwo.PlacePeople();

            ferryTwo.CountOccupiedSeats().Should().Be(2066);
        }
    }
}