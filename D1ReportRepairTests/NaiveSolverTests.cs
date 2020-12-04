using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReportRepair.Tests
{
    [TestClass]
    public class NaiveSolverTests
    {
        [TestMethod]
        public void Get2NumbersWithSumEqualToTest()
        {
            var numbers = Program.ReadInput(Program.InputTxt);

            var (n1, n2) = new NaiveSolver(numbers).Get2NumbersWithSumEqualTo(Program.SumToFind);

            (n1 + n2).Should().Be(Program.SumToFind);
        }

        [TestMethod]
        public void Get3NumbersWithSumEqualToTest()
        {
            var numbers = Program.ReadInput(Program.InputTxt);

            var (n1, n2, n3) = new NaiveSolver(numbers).Get3NumbersWithSumEqualTo(Program.SumToFind);

            (n1 + n2 + n3).Should().Be(Program.SumToFind);
        }
    }
}