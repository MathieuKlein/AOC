using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace D7HandyHaversacks.Tests
{
    [TestClass]
    public class BagRulesTests
    {
        [TestMethod]
        public void GetBagThatCanContainExample_Then4()
        {
            var strings = new List<string>
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags."
            };

            var bagRules = new BagRules(strings);

            bagRules.GetBagThatCanContain(Program.ShinyGold).Count.Should().Be(4);
        }

        [TestMethod]
        public void GetBagThatCanContainTest()
        {
            var strings = File.ReadLines(Program.InputTxt);

            var bagRules = new BagRules(strings);

            bagRules.GetBagThatCanContain(Program.ShinyGold).Count.Should().Be(265);
        }

        [TestMethod]
        public void CountBagsInsideExample_Then126()
        {
            var strings = new List<string>
            {
                "shiny gold bags contain 2 dark red bags.",
                "dark red bags contain 2 dark orange bags.",
                "dark orange bags contain 2 dark yellow bags.",
                "dark yellow bags contain 2 dark green bags.",
                "dark green bags contain 2 dark blue bags.",
                "dark blue bags contain 2 dark violet bags.",
                "dark violet bags contain no other bags."
            };

            var bagRules = new BagRules(strings);

            bagRules.CountBagsInside(Program.ShinyGold).Should().Be(126);
        }

        [TestMethod]
        public void CountBagsInsideTest()
        {
            var strings = File.ReadLines(Program.InputTxt);

            var bagRules = new BagRules(strings);

            bagRules.CountBagsInside(Program.ShinyGold).Should().Be(14177);
        }
    }
}