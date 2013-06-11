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
    public class NumberToRomanConverterTest
    {
        [Test]
        [TestCase(1, "I")]
        [TestCase(5, "V")]
        [TestCase(10, "X")]
        [TestCase(9, "IX")]
        [TestCase(7, "VII")]
        [TestCase(4, "IV")]
        [TestCase(18, "XVIII")]
        [TestCase(24, "XXIV")]
        [TestCase(50, "L")]
        [TestCase(40, "XL")]
        [TestCase(60, "LX")]
        [TestCase(369, "CCCLXIX")]
        [TestCase(448, "CDXLVIII")]
        [TestCase(999, "CMXCIX")]
        [TestCase(1999, "MCMXCIX")]
        public void Convert_Number_ShouldBeRoman(int number, string roman)
        {
            var converter = new NumberToRomanConverter();

            var result = converter.Convert(number);

            result.Should().Be(roman);
        }
    }
}
