using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataFizzBuzz
{
    class FizzBuzz
    {
        private readonly Dictionary<Func<int, bool>, string> _rules = new Dictionary<Func<int, bool>, string> 
        {
            { (x) => x % 3 == 0 || x.ToString().Contains("3"), "Fizz" },
            { (x) => x % 5 == 0 || x.ToString().Contains("5"), "Buzz" },
        };

        internal string Speak(int number)
        {
            var sb = new StringBuilder();

            foreach (var rule in _rules)
            {
                if (rule.Key(number)) 
                {
                    sb.Append(rule.Value);
                }
            }

            return sb.ToString();
        }
    }
}
