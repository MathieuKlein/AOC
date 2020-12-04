using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordPhilosophy.Tests
{
    [TestClass]
    public class IsInPosition1XOrPosition2StrategyTests
    {
        [TestMethod]
        public void IsValid_WhenOne_ThenTrue()
        {
            new IsInPosition1XOrPosition2Strategy().IsValid(new Line("abcde", 'a', 1, 3)).Should().BeTrue();
        }

        [TestMethod]
        public void IsValidTest_WhenNeither_ThenFalse()
        {
            new IsInPosition1XOrPosition2Strategy().IsValid(new Line("cdefg", 'b', 1, 3)).Should().BeFalse();
        }

        [TestMethod]
        public void IsValidTest_WhenBoth_ThenFalse()
        {
            new IsInPosition1XOrPosition2Strategy().IsValid(new Line("ccccccccc", 'c', 2, 9)).Should().BeFalse();
        }
    }
}