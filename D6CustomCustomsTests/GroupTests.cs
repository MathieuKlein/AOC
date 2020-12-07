using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace D6CustomCustoms.Tests
{
    [TestClass]
    public class GroupTests
    {
        [TestMethod]
        public void LettersOnceYes_WhenExample1_Then3()
        {
            new Group(new List<string> { "abc" }).LettersOnceYes.Should().HaveCount(3);
        }

        [TestMethod]
        public void LettersOnceYes_WhenExample2_Then0()
        {
            new Group(new List<string> { "a", "b", "c" }).LettersOnceYes.Should().HaveCount(3);
        }


        [TestMethod]
        public void LettersOnceYes_WhenExample3_Then1()
        {
            new Group(new List<string> { "ab", "bc" }).LettersOnceYes.Should().HaveCount(3);
        }

        [TestMethod]
        public void LettersOnceYes_WhenExample4_Then1()
        {
            new Group(new List<string> { "a", "a", "a" }).LettersOnceYes.Should().HaveCount(1);
        }

        [TestMethod]
        public void LettersOnceYes_WhenExample5_Then1()
        {
            new Group(new List<string> { "b" }).LettersOnceYes.Should().HaveCount(1);
        }

        [TestMethod]
        public void LettersYesTest()
        {
            var strings = File.ReadLines(Program.InputTxt);
            var groups = Program.GetGroup(strings);

            groups.Select(x => x.LettersOnceYes.Count).Sum().Should().Be(6930);
        }

        [TestMethod]
        public void GetAllQuestionsAnsweredYes_WhenExample1_Then3()
        {
            new Group(new List<string> { "abc" }).GetAllQuestionsAnsweredYes().Should().HaveCount(3);
        }

        [TestMethod]
        public void GetAllQuestionsAnsweredYes_WhenExample2_Then0()
        {
            new Group(new List<string> { "a", "b", "c" }).GetAllQuestionsAnsweredYes().Should().HaveCount(0);
        }


        [TestMethod]
        public void GetAllQuestionsAnsweredYes_WhenExample3_Then1()
        {
            new Group(new List<string> { "ab", "bc" }).GetAllQuestionsAnsweredYes().Should().HaveCount(1);
        }

        [TestMethod]
        public void GetAllQuestionsAnsweredYes_WhenExample4_Then1()
        {
            new Group(new List<string> { "a", "a", "a" }).GetAllQuestionsAnsweredYes().Should().HaveCount(1);
        }

        [TestMethod]
        public void GetAllQuestionsAnsweredYes_WhenExample5_Then1()
        {
            new Group(new List<string> { "b" }).GetAllQuestionsAnsweredYes().Should().HaveCount(1);
        }

        [TestMethod]
        public void GetAllQuestionsAnsweredYesTest()
        {
            var strings = File.ReadLines(Program.InputTxt);
            var groups = Program.GetGroup(strings);

            groups.Select(x => x.GetAllQuestionsAnsweredYes().Count()).Sum().Should().Be(3585);
        }
    }
}