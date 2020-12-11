using System.IO;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace D10AdapterArray.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void GetNumbersOfOneAndThreeGapsTest()
        {
            var strings = File.ReadLines(Program.InputTxt);
            var solver = new Solver(strings);

            var numbersOfOneAndThreeGaps = solver.GetNumbersOfOneAndThreeGaps();

            (numbersOfOneAndThreeGaps.x * numbersOfOneAndThreeGaps.y).Should().Be(2484);
        }

        [TestMethod]
        public void GetNumberOfPathFromOutletToDeviceTest()
        {
            var strings = File.ReadLines(Program.InputTxt);
            var solver = new Solver(strings);

            solver.GetNumberOfPathFromOutletToDevice().Should().Be(15790581481472L);
        }
    }
}