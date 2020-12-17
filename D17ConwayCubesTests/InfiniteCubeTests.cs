using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace D17ConwayCubes.Tests
{
    [TestClass]
    public class InfiniteCubeTests
    {
        [TestMethod]
        public void ApplyRulesTest()
        {
            var strings = File.ReadLines(Program.InputTxt).ToList();

            var infiniteCube = new InfiniteCube();

            for (var i = 0; i < strings.Count; i++)
            for (var j = 0; j < strings[i].Length; j++)
                infiniteCube.Set(i, j, 0, strings[i][j]);

            for (var i = 0; i < 6; i++)
                infiniteCube.ApplyRules();

            infiniteCube.GetNumberOfActiveCell().Should().Be(368);
        }
    }
}