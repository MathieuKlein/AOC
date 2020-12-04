using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReportRepair.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Get3NumbersWithSumEqualToTest()
        {
            var numbers = Program.ReadInput(Program.InputTxt);
            var (n1, n2, n3) = Program.Get3NumbersWithSumEqualTo(numbers, Program.SumToFind);

            (n1 + n2 + n3).Should().Be(Program.SumToFind);
        }

        [TestMethod]
        public void Get2NumbersWithSumEqualToTest()
        {
            var numbers = Program.ReadInput(Program.InputTxt);
            var (n1, n2) = Program.Get2NumbersWithSumEqualTo(numbers, Program.SumToFind);

            (n1 + n2).Should().Be(Program.SumToFind);
        }
    }
}