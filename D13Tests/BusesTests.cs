using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace D13ShuttleSearch.Tests
{
    [TestClass]
    public class BusesTests
    {
        [TestMethod]
        public void MinNextBusTest()
        {
            var strings = File.ReadLines(Program.InputTxt).ToList();

            var timestamp = long.Parse(strings.First());
            var busesStrings = strings.Skip(1).First().Split(',');
            var buses = new Buses(busesStrings);

            var (bus, nextIn) = buses.MinNextBus(timestamp);
            (bus.Frequency * nextIn).Should().Be(3865L);
        }

        [TestMethod]
        public void MinTimestampWhenBusesAreInCorrectPositionTest()
        {
            var strings = File.ReadLines(Program.InputTxt).ToList();
            var busesStrings = strings.Skip(1).First().Split(',');
            var buses = new Buses(busesStrings);

            buses.MinTimestampWhenBusesAreInCorrectPosition().Should().Be(415579909629976L);
        }
    }
}