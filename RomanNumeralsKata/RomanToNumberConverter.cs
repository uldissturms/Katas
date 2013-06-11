using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumeralsKata
{
    public class RomanToNumberConverter
    {
        internal int Convert(string roman)
        {
            var number = 0;

            for (int i = 0; i < roman.Length; i++)
            {
                var current = RomanNumeralRepository.Numerals.First(x => x.Value == roman[i].ToString()).Number;
                var next = i < roman.Length - 1 ?
                    RomanNumeralRepository.Numerals.First(x => x.Value == roman[i + 1].ToString()).Number
                    : 0;

                if (next > current)
                {
                    number -= current;
                }
                else
                {
                    number += current;
                }
            }

            return number;
        }
    }
}
