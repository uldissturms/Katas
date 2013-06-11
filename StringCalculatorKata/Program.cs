using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    internal class Program
    {
        internal static void Main(params string[] args)
        {
            new Program().Run(args);
        }

        internal void Run(params string[] args)
        {
            var numbers = args != null && args.Any()
                ? args[0]
                : GetNextUserInput();
            while (!string.IsNullOrEmpty(numbers))
            {
                Add(numbers);
                numbers = GetNextUserInput();
            }
        }

        private string GetNextUserInput()
        {
            Console.WriteLine("Another input please");
            return GetNumbers();
        }

        protected virtual string GetNumbers()
        {
            return Console.ReadLine();
        }

        internal void Add(string numbers)
        {
            var calculator = new StringCalculator(new[] { "," });
            var result = calculator.Add(numbers);
            Console.WriteLine(string.Format("The result is {0}", result));
        }
    }
}
