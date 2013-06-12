using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace PrimeFactorsKata
{
    [TestFixture]
    public class PrimeFactorsTest
    {
        [Test]
        public void Generate_One_EmptyList()
        {
            PrimeFactors.Generate(1).Should().BeEmpty();
        }

        [TestCase(2)]
        [TestCase(3)]
        public void Generate_MulitpleOfOne_ListWithTheNumber(int number)
        {
            PrimeFactors.Generate(number).Should().BeEquivalentTo(new[] { number });
        }

        [Test]
        public void Generate_Four_ListOfTwoTwos()
        {
            PrimeFactors.Generate(4).Should().BeEquivalentTo(new [] { 2, 2 });
        }

        [Test]
        public void Generate_Six_ListOfTwoAndThree()
        {
            PrimeFactors.Generate(6).Should().BeEquivalentTo(new [] { 2, 3 });
        }

        [Test]
        public void Generate_Eight_ListOfThreeTwos()
        {
            PrimeFactors.Generate(8).Should().BeEquivalentTo(new[] { 2, 2, 2 });
        }

        [Test]
        public void Generate_Nine_ListOfTwoThrees()
        {
            PrimeFactors.Generate(9).Should().BeEquivalentTo(new [] { 3, 3 });
        }
    }
}
