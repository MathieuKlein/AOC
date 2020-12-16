using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace D16TicketTranslation.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Problem2Test()
        {
            var strings = File.ReadLines(Program.InputTxt).ToList();

            var inputData = new InputData(strings);

            var wrongTickets = Program.GetWrongTickets(inputData);

            wrongTickets.Sum(x => x.WrongValue).Should().Be(21996);


            var valueOfMyTicketStartingByDeparture = Program.GetValueOfMyTicketStartingBy(inputData, "departure");

            valueOfMyTicketStartingByDeparture.Aggregate((x, y) => x * y).Should().Be(650080463519);
        }

        [TestMethod]
        public void Problem1Test()
        {
            var strings = File.ReadLines(Program.InputTxt).ToList();

            var inputData = new InputData(strings);

            var wrongTickets = Program.GetWrongTickets(inputData);

            wrongTickets.Sum(x => x.WrongValue).Should().Be(21996);
        }
    }
}