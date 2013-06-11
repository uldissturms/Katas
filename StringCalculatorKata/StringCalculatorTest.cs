using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace StringCalculatorKata
{
    [TestFixture]
    public class StringCalculatorTest
    {
        private StringCalculator GetCalculator(string[] delimiters = null)
        {
            var tmp = delimiters ?? new[] { "," };
            return new StringCalculator(tmp);
        }

        [Test]
        public void Add_Empty_ReturnsZero()
        {
            var calc = GetCalculator();

            var result = calc.Add("");

            result.Should().Be(0);
        }

        [Test]
        public void Add_OneNumber_ReturnsNumber()
        {
            var calc = GetCalculator();

            var result = calc.Add("1");

            result.Should().Be(1);
        }

        [Test]
        public void Add_TwoNumbers_ReturnsSumOfThem()
        {
            var calc = GetCalculator();

            var result = calc.Add("1,2");

            result.Should().Be(3);
        }

        [Test]
        public void Add_ThreeNumbersWithDifferentDelimiters_ReturnsSumOfThem()
        {
            var calc = GetCalculator(new[] { ",", "\n" });

            var result = calc.Add("1\n2,3");

            result.Should().Be(6);
        }

        [Test]
        public void Add_CommentWithDelimiterAndNewLine_ShouldAddAcceptedDelimiter()
        {
            var calc = GetCalculator(new[] { "," });

            var result = calc.Add("//;\n1;2");

            result.Should().Be(3);
        }

        [Test]
        public void Add_NegativeNumber_ShouldThrowWithNumberInMessage()
        {
            var calc = GetCalculator();

            Action action = () => calc.Add("1,-2");

            action.ShouldThrow<ApplicationException>()
                .WithMessage("Negatives not allowed: -2");
        }

        [Test]
        public void Add_MultipleNegativeNumbers_ShouldThrowWithAllNumbersInMessage()
        {
            var calc = GetCalculator();

            Action action = () => calc.Add("1,-2,-3");

            action.ShouldThrow<ApplicationException>()
                .WithMessage("Negatives not allowed: -2,-3");
        }

        [Test]
        public void Add_NumberBiggerThan1000_ShouldBeIgnored()
        {
            var calc = GetCalculator();

            var result = calc.Add("2,1001");

            result.Should().Be(2);
        }

        [Test]
        public void Add_CommentWithDelimitersOfAnyLengthInSquareBracketsAndNewLine_ShouldAddAcceptedDelimiter()
        {
            var calc = GetCalculator(new[] { "," });

            var result = calc.Add("//[***]\n1***2");

            result.Should().Be(3);
        }

        [Test]
        public void Add_CommentWithMultipleDelimitersInSquareBracketsAndNewLine_ShouldAddAcceptedDelimiter()
        {
            var calc = GetCalculator(new[] { "," });

            var result = calc.Add("//[*][%]\n1*2%3");

            result.Should().Be(6);
        }
    }
}
