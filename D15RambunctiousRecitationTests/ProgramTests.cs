using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace D15RambunctiousRecitation.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void GetValueAt2009Test()
        {
            Program.GetValueAtN(Program.Input.Split(','), 2020).Should().Be(253);
        }

        [TestMethod]
        public void GetValueAt30000000Test()
        {
            Program.GetValueAtN(Program.Input.Split(','), 30000000).Should().Be(13710);
        }
    }
}