using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace D4PassportProcessing.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ContainsRequiredFields_WhenExample1_ThenTrue()
        {
            var passeports = Program.GetPasseports(new List<string>
            {
                "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd",
                "byr:1937 iyr:2017 cid:147 hgt:183cm"
            });

            passeports.Single().ContainsRequiredFields().Should().BeTrue();
        }

        [TestMethod]
        public void ContainsRequiredFields_WhenExample2_ThenFalse()
        {
            var passeports = Program.GetPasseports(new List<string>
            {
                "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884",
                "hcl:#cfa07d byr:1929"
            });

            passeports.Single().ContainsRequiredFields().Should().BeFalse();
        }

        [TestMethod]
        public void ContainsRequiredFields_WhenExample3_ThenTrue()
        {
            var passeports = Program.GetPasseports(new List<string>
            {
                "hcl:#ae17e1 iyr:2013",
                "eyr:2024",
                "ecl:brn pid:760753108 byr:1931",
                "hgt:179cm"
            });

            passeports.Single().ContainsRequiredFields().Should().BeTrue();
        }

        [TestMethod]
        public void ContainsRequiredFields_WhenExample4_ThenFalse()
        {
            var passeports = Program.GetPasseports(new List<string>
            {
                "hcl:#cfa07d eyr:2025 pid:166559648",
                "iyr:2011 ecl:brn hgt:59in"
            });

            passeports.Single().ContainsRequiredFields().Should().BeFalse();
        }

        [TestMethod]
        public void CountContainsRequiredFields_Then170()
        {
            var strings = File.ReadLines(Program.InputTxt);
            var passeports = Program.GetPasseports(strings);

            var validPasseports = passeports.Count(x => x.ContainsRequiredFields());

            validPasseports.Should().Be(170);
        }


        [TestMethod]
        public void IsValid_WhenExample1_ThenFalse()
        {
            var passeports = Program.GetPasseports(new List<string>
            {
                "eyr:1972 cid:100",
                "hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926"
            });

            passeports.Single().IsValid().Should().BeFalse();
        }

        [TestMethod]
        public void IsValid_WhenExample2_ThenFalse()
        {
            var passeports = Program.GetPasseports(new List<string>
            {
                "iyr:2019",
                "hcl:#602927 eyr:1967 hgt:170cm",
                "ecl:grn pid:012533040 byr:1946"
            });

            passeports.Single().IsValid().Should().BeFalse();
        }

        [TestMethod]
        public void IsValid_WhenExample3_ThenFalse()
        {
            var passeports = Program.GetPasseports(new List<string>
            {
                "hcl:dab227 iyr:2012",
                "ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277"
            });

            passeports.Single().IsValid().Should().BeFalse();
        }

        [TestMethod]
        public void IsValid_WhenExample4_ThenFalse()
        {
            var passeports = Program.GetPasseports(new List<string>
            {
                "hgt:59cm ecl:zzz",
                "eyr:2038 hcl:74454a iyr:2023",
                "pid:3556412378 byr:2007"
            });

            passeports.Single().IsValid().Should().BeFalse();
        }

        [TestMethod]
        public void IsValid_WhenExample5_ThenTrue()
        {
            var passeports = Program.GetPasseports(new List<string>
            {
                "pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980",
                "hcl:#623a2f"
            });

            passeports.Single().IsValid().Should().BeTrue();
        }

        [TestMethod]
        public void IsValid_WhenExample6_ThenTrue()
        {
            var passeports = Program.GetPasseports(new List<string>
            {
                "eyr:2029 ecl:blu cid:129 byr:1989",
                "iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm"
            });

            passeports.Single().IsValid().Should().BeTrue();
        }

        [TestMethod]
        public void IsValid_WhenExample7_ThenTrue()
        {
            var passeports = Program.GetPasseports(new List<string>
            {
                "hcl:#888785",
                "hgt:164cm byr:2001 iyr:2015 cid:88",
                "pid:545766238 ecl:hzl",
                "eyr:2022"
            });

            passeports.Single().IsValid().Should().BeTrue();
        }

        [TestMethod]
        public void IsValid_WhenExample8_ThenTrue()
        {
            var passeports = Program.GetPasseports(new List<string>
            {
                "iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719"
            });

            passeports.Single().IsValid().Should().BeTrue();
        }

        [TestMethod]
        public void CountIsValid_Then103()
        {
            var strings = File.ReadLines(Program.InputTxt);
            var passeports = Program.GetPasseports(strings);

            var validPasseports = passeports.Count(x => x.IsValid());

            validPasseports.Should().Be(103);
        }
    }
}