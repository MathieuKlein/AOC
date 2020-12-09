using System.IO;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace D8HandheldHalting.Tests
{
    [TestClass]
    public class BootLoaderTests
    {
        [TestMethod]
        public void GetLastValueAccumulatorWhenFirstRoundEnd_Then1262()
        {
            var strings = File.ReadLines(Program.InputTxt);

            var bootLoader = new BootLoader(strings);

            bootLoader.GetLastValueAccumulatorWhenFirstRoundEnd().Should().Be(1262);
        }


        [TestMethod]
        public void GetLastValueAccumulatorWhenTerminates_Then1643()
        {
            var strings = File.ReadLines(Program.InputTxt);

            var bootLoader = new BootLoader(strings);

            bootLoader.GetLastValueAccumulatorWhenTerminates().Should().Be(1643);
        }
    }
}