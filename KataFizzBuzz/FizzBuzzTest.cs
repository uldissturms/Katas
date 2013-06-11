using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace KataFizzBuzz
{
    [TestFixture]
    public class FizzBuzzTest
    {
        [Test]
        public void Speak_DoesNotMatchFizzOrBuzz_Silence()
        {
            var fizzBuzz = new FizzBuzz();

            var result = fizzBuzz.Speak(1);

            result.Should().BeEmpty();
        }

        [TestCase(3)]
        [TestCase(6)]
        public void Speak_MultipleOf3_Fizz(int number)
        {
            var fizzBuzz = new FizzBuzz();

            var result = fizzBuzz.Speak(number);

            result.Should().Be("Fizz");
        }

        [TestCase(5)]
        [TestCase(10)]
        public void Speak_MultipleOf5_Buzz(int number)
        {
            var fizzBuzz = new FizzBuzz();

            var result = fizzBuzz.Speak(number);

            result.Should().Be("Buzz");
        }

        [TestCase(15)]
        [TestCase(30)]
        public void Speak_MultipleOf3And5_FizzBuzz(int number)
        {
            var fizzBuzz = new FizzBuzz();

            var result = fizzBuzz.Speak(number);

            result.Should().Be("FizzBuzz");
        }

        [TestCase(13)]
        [TestCase(23)]
        public void Speak_Contains3_Fizz(int number)
        {
            var fizzBuzz = new FizzBuzz();

            var result = fizzBuzz.Speak(number);

            result.Should().Be("Fizz");
        }

        [TestCase(25)]
        [TestCase(55)]
        public void Speak_Contains5_Buzz(int number)
        {
            var fizzBuzz = new FizzBuzz();

            var result = fizzBuzz.Speak(number);

            result.Should().Be("Buzz");
        }
    }
}
