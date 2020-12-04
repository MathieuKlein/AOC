using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordPhilosophy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace PasswordPhilosophy.Tests
{
    [TestClass()]
    public class IsBetweenMinAndMaxStrategyTests
    {
        [TestMethod]
        public void IsValid_WhenBetweenMinMax_ThenTrue()
        {
            new IsBetweenMinAndMaxStrategy().IsValid(new Line("abcde", 'a', 1, 3)).Should().BeTrue();
        }

        [TestMethod()]
        public void IsValid_WhenLessThanMin_ThenTrue()
        {
            new IsBetweenMinAndMaxStrategy().IsValid(new Line("cdefg", 'b', 1, 3)).Should().BeFalse();
        }

        [TestMethod()]
        public void IsValid_WhenMoreThanMax_ThenTrue()
        {
            new IsBetweenMinAndMaxStrategy().IsValid(new Line("cdefgbbbb", 'b', 1, 3)).Should().BeFalse();
        }

        [TestMethod()]
        public void IsValidTest()
        {
            new IsBetweenMinAndMaxStrategy().IsValid(new Line("ccccccccc", 'c', 2, 9)).Should().BeTrue();
        }
    }
}