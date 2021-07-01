using System;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace PowerSumChallenge
{
    // 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

    // What is the sum of the digits of the number 2^x?

    public class Challenge
    {
        public int Execute(int x)
        {
            var pow = (BigInteger)Math.Pow(2, x);

            return pow.ToString(CultureInfo.InvariantCulture)
                .Select(@char => int.Parse(@char.ToString(CultureInfo.InvariantCulture), NumberStyles.None, CultureInfo.InvariantCulture))
                .Sum();
        }
    }
}
