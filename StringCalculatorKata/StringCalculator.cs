using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private const int _ignoreNumbersBiggerThan = 1000;

        private const string _delimiterComments = @"//";
        private const string _delimiterPatter = @"\[(.*?)\]";
        private const string _newline = "\n";

        private readonly List<string> _delimiters;

        public StringCalculator(string [] delimiters)
        {
            _delimiters = delimiters.ToList();
        }

        internal int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            numbers = ProcessDelimiterDeclaration(numbers);

            var list = numbers.Split(_delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .Where(x => x <= _ignoreNumbersBiggerThan);

            var negativeNumbers = list.Where(x => x < 0);

            if (negativeNumbers.Any())
            {
                throw new ApplicationException(string.Format("Negatives not allowed: {0}", string.Join(",", negativeNumbers)));
            }

            return list.Sum();
        }

        private string ProcessDelimiterDeclaration(string numbers)
        {
            if (numbers.StartsWith(_delimiterComments))
            {
                var endOfDelimiters = numbers.IndexOf(_newline);
                var delimiters = numbers.Substring(_delimiterComments.Length, endOfDelimiters - _delimiterComments.Length);
                var matches = Regex.Matches(delimiters, _delimiterPatter);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        _delimiters.Add(match.Groups[1].Value);
                    }
                }
                else
                {
                    _delimiters.Add(delimiters);
                }

                numbers = numbers.Substring(endOfDelimiters + 1);
            }

            return numbers;
        }
    }
}
