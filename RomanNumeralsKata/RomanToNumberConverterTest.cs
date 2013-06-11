using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace RomanNumeralsKata
{
    [TestFixture]
    public class RomanToNumberConverterTest
    {
        [Test]
        [TestCase("I", 1)]
        [TestCase("V", 5)]
        [TestCase("X", 10)]
        [TestCase("IX", 9)]
        [TestCase("VII", 7)]
        [TestCase("IV", 4)]
        [TestCase("XVIII", 18)]
        [TestCase("XXIV", 24)]
        [TestCase("L", 50)]
        [TestCase("XL", 40)]
        [TestCase("LX", 60)]
        [TestCase("CCCLXIX", 369)]
        [TestCase("CDXLVIII", 448)]
        [TestCase("CMXCIX", 999)]
        [TestCase("MCMXCIX", 1999)]
        public void Convert_Roman_ShouldBeNumber(string roman, int number)
        {
            var converter = new RomanToNumberConverter();

            var result = converter.Convert(roman);

            result.Should().Be(number);
        }
    }
}
