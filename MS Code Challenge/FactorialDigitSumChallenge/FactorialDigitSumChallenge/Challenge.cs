using System.Globalization;
using System.Linq;
using System.Numerics;

namespace FactorialDigitSumChallenge
{
    //n! means n × (n − 1) × ... × 3 × 2 × 1

    //For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
    //and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

    //Find the sum of the digits in the number x!

    public class Challenge
    {
        public int Execute(int x)
        {
            BigInteger numberToCalculateSum = x;
            while (x > 1)
            {
                x--;
                numberToCalculateSum *= x;
            }
            return numberToCalculateSum.ToString(CultureInfo.InvariantCulture)
                .Select(@char => int.Parse(@char.ToString(CultureInfo.InvariantCulture), NumberStyles.None, CultureInfo.InvariantCulture))
                .Sum();
        }
    }
}