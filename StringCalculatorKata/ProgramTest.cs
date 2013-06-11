using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace StringCalculatorKata
{
    [TestFixture]
    public class ProgramTest
    {
        [Test]
        public void Add_Numbers_SumShouldBeOutputToConsole()
        {
            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            {
                Console.SetOut(sw);
                new Program().Add("1,2,3");
            }

            sb.ToString().Should().Be(string.Format("The result is 6{0}", Environment.NewLine));
        }

        [Test]
        public void Run_NoNumbers_UserShouldBeToldToEnterNumbers()
        {
            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            {
                Console.SetOut(sw);
                new FakeProgram().Run();
            }

            sb.ToString().Should().Be(string.Format("Another input please{0}", Environment.NewLine));
        }

        [Test]
        public void Run_ValidNumbers_UserShouldBeToldToEnterAnotherNumbers()
        {
            var program = new FakeProgram();

            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            {
                Console.SetOut(sw);
                program.Run("1,2,3");
            }

            var expected = new StringBuilder();
            expected.AppendLine("The result is 6");
            expected.AppendLine("Another input please");

            sb.ToString().Should().Be(expected.ToString());
        }

        [Test]
        public void Run_ValidNumbersProvidedTwiceAndEmptyString_TwoSumsAndTwoEnterAnotherNumbersShouldBeOutputToConsole()
        {
            var program = new FakeProgram()
                .WithNumbers("1,2");

            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            {
                Console.SetOut(sw);
                program.Run("1,2,3");
            }

            var expected = new StringBuilder();
            expected.AppendLine("The result is 6");
            expected.AppendLine("Another input please");
            expected.AppendLine("The result is 3");
            expected.AppendLine("Another input please");

            sb.ToString().Should().Be(expected.ToString());
        }

        private class FakeProgram : Program
        {
            private int _times = 1;
            private string _numbers;

            internal FakeProgram WithNumbers(string numbers)
            {
                _numbers = numbers;
                return this;
            }

            protected override string GetNumbers()
            {
                _times--;
                if (_times < 0)
                {
                    return string.Empty;
                }

                return _numbers;
            }
        }
    }
}
