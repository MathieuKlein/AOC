using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace D9EncodingError.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void GetFirstNumberNotEqualToNPrecedentTest()
        {
            var strings = File.ReadLines(Program.InputTxt);
            var decryptor = new Decryptor(strings);

            decryptor.GetFirstNumberNotEqualToNPrecedent(25).Should().Be(167829540);
        }

        [TestMethod]
        public void GetContiguousSetThatSumToTest()
        {
            var strings = File.ReadLines(Program.InputTxt);
            var decryptor = new Decryptor(strings);

            var contiguousSetThatSumTo = decryptor.GetContiguousSetThatSumTo(167829540);

            (contiguousSetThatSumTo.Min() + contiguousSetThatSumTo.Max()).Should().Be(28045630);
        }
    }
}