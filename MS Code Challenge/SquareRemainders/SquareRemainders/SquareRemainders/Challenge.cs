using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRemainders
{
    public class Challenge
    {
        /* Square Remainder Challenge
         * 
         * Here's a challenge for the math lovers. Solving this challenge can be done in 4 lines of code (inside of the method) but getting to the right solution can be tricky!
         * 
         * Here we go:
         * 
         * Let r be the remainder when (a−1)^n + (a+1)^n is divided by a^2.
         * 
         * I.e.,    r = ((a−1)^n + (a+1)^n) % a^2
         * 
         * Example: If a = 7 and n = 3,
         *          then r = 42.
         *          Because:   ((7-1)^3 + (7+1)^3) % 7^2
         *                   = (6^3 + 8^3) % 49
         *                   = (216 + 512) % 49
         *                   = 728 % 49
         *                   = 42
         *          
         *          And as n varies, r will too, but for a = 7 it turns out that r_max = 42.
         *          
         * You will receive two inputs to your method: a lower limit (integer) and an upper limit (integer).
         * 
         * You need to make the Execute method return the SUM of r_max for:
         *          
         *          lowerLimit <= a <= upperLimit
         *          
         * You will have to iterate over all possible values of a from the lower limit to the upper limit (including both limits).
         * Then, you need to add the r_max of each iteration to a sum, which your method shall return (integer).
         * 
         * Good luck!
         */

        public int Execute(int lowerLimit, int upperLimit)
        {
            int r = 0;
            for (int a = lowerLimit; a <= upperLimit; a++)
            {
                r += 2 * a * ((a - 1) / 2);
            }
            return r;
        }
    }
}
