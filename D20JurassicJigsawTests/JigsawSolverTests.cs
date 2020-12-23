using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace D20JurassicJigsaw.Tests
{
    [TestClass]
    public class JigsawSolverTests
    {
        [TestMethod]
        public void GetCornersTest()
        {
            var strings = File.ReadLines(Program.InputTxt);
            var jigsawSolver = new JigsawSolver(strings);

            var corners = jigsawSolver.GetCorners();

            corners.Aggregate((x, y) => x * y).Should().Be(29584525501199);
        }

        [TestMethod]
        public void GetSolveTest()
        {
            var strings = File.ReadLines(Program.InputTxt);
            var jigsawSolver = new JigsawSolver(strings);

            var finalGrid = jigsawSolver.Solve();
            jigsawSolver.CountMonsters(finalGrid).Should().Be(1665);
        }
    }
}