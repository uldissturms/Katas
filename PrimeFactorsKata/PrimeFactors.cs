using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactorsKata
{
    public class PrimeFactors
    {
        public static List<int> Generate(int number)
        {
            var primes = new List<int> { };

            for (int candidate = 2; number > 1; candidate++ )
            {
                for (; number % candidate == 0; number /= candidate)
                {
                    primes.Add(candidate);
                }
            }

            return primes;
        }
    }
}
