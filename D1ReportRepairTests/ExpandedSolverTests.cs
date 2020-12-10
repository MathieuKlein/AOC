using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReportRepair.Tests
{
    [TestClass]
    public class ExpandedSolverTests
    {
        [DataTestMethod]
        [DataRow(2, 1005459)]
        [DataRow(3, 92643264)]
        public void GetNNumbersWithSumEqualTo(int n, int result)
        {
            var numbers = Program.ReadInput(Program.InputTxt);

            var p = new ExpandedSolver(numbers).GetNNumbersWithSumEqualTo(n, Program.SumToFind);

            p.Aggregate((x, y) => x * y).Should().Be(result);
        }


        [TestMethod]
        public void Generate3UpletsTest()
        {
            var numbers = new long[] { 1, 2, 3 };

            var expected = new[]
            {
                new[] { 1, 1, 1 },
                new[] { 1, 1, 2 },
                new[] { 1, 1, 3 },
                new[] { 1, 2, 1 },
                new[] { 1, 2, 2 },
                new[] { 1, 2, 3 },
                new[] { 1, 3, 1 },
                new[] { 1, 3, 2 },
                new[] { 1, 3, 3 },
                new[] { 2, 1, 1 },
                new[] { 2, 1, 2 },
                new[] { 2, 1, 3 },
                new[] { 2, 2, 1 },
                new[] { 2, 2, 2 },
                new[] { 2, 2, 3 },
                new[] { 2, 3, 1 },
                new[] { 2, 3, 2 },
                new[] { 2, 3, 3 },
                new[] { 3, 1, 1 },
                new[] { 3, 1, 2 },
                new[] { 3, 1, 3 },
                new[] { 3, 2, 1 },
                new[] { 3, 2, 2 },
                new[] { 3, 2, 3 },
                new[] { 3, 3, 1 },
                new[] { 3, 3, 2 },
                new[] { 3, 3, 3 }
            };

            var result = new ExpandedSolver(numbers).GenerateNUplets(3).ToList();

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Generate2UpletsTest()
        {
            var numbers = new long[] { 1, 2, 3 };

            var expected = new[]
            {
                new[] { 1, 1 },
                new[] { 1, 2 },
                new[] { 1, 3 },
                new[] { 2, 1 },
                new[] { 2, 2 },
                new[] { 2, 3 },
                new[] { 3, 1 },
                new[] { 3, 2 },
                new[] { 3, 3 }
            };

            var result = new ExpandedSolver(numbers).GenerateNUplets(2).ToList();

            result.Should().BeEquivalentTo(expected);
        }
    }
}