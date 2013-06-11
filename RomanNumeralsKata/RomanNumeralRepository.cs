using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralsKata
{
    public class RomanNumeralRepository
    {
        public static readonly List<RomanNumeral> Numerals = new List<RomanNumeral>
        {
            new RomanNumeral { Number = 1, Precision = 1, Value = "I" },
            new RomanNumeral { Number = 5, Precision = 1, Value = "V" },
            new RomanNumeral { Number = 10, Precision = 10, Value = "X" },
            new RomanNumeral { Number = 50, Precision = 10, Value = "L" },
            new RomanNumeral { Number = 100, Precision = 100, Value = "C" },
            new RomanNumeral { Number = 500, Precision = 100, Value = "D" },
            new RomanNumeral { Number = 1000, Precision = 1000, Value = "M" },
        };
    }
}
