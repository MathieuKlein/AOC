using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace D14DockingData.Tests
{
    [TestClass]
    public class DockDecoderV1Tests
    {
        [TestMethod]
        public void DecodeTest()
        {
            var strings = File.ReadLines(Program.InputTxt).ToList();

            var decoder = new DockDecoderV1(strings);

            decoder.Decode().Values.Sum().Should().Be(16003257187056L);
        }
    }
}