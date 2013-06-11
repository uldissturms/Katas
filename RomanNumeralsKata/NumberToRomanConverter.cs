using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumeralsKata
{
    class NumberToRomanConverter
    {
        internal string Convert(int number)
        {
            var sb = new StringBuilder();
            var max = RomanNumeralRepository.Numerals.OrderByDescending(x => x.Number)
                .First(x => number >= x.Number);

            var special = ProcessSpecialCases(number, max);
            if (special != null)
            {
                number -= special.Number;
                sb.Append(special.Value);
            }
            else
            {
                sb.Append(max.Value);
                number -= max.Number;
            }

            if (number > 0)
            {
                sb.Append(Convert(number));
            }

            return sb.ToString();
        }

        private RomanNumeral ProcessSpecialCases(int number, RomanNumeral max)
        {
            if (number == max.Number)
            {
                return null;
            }

            var greater = RomanNumeralRepository.Numerals.OrderBy(x => x.Number)
                .Where(x => max.Number < x.Number);
            var less = RomanNumeralRepository.Numerals.OrderByDescending(x => x.Number)
                .Where(x => number > x.Number);

            var closestGreater = greater.FirstOrDefault();
            var nextLess = less.Skip(1).FirstOrDefault();

            if (closestGreater == null)
            {
                return null;
            }

            var roundedValueToPrecision = ((int)(number / max.Precision) * max.Precision);

            if (nextLess != null && roundedValueToPrecision == closestGreater.Number - nextLess.Number)
            {
                return new RomanNumeral { Number = closestGreater.Number - nextLess.Number, Value = string.Join("", nextLess.Value, closestGreater.Value) };
            }

            if (roundedValueToPrecision == closestGreater.Number - max.Number)
            {
                return new RomanNumeral { Number = closestGreater.Number - max.Number, Value = string.Join("", max.Value, closestGreater.Value) };
            }

            return null;
        }
    }
}
