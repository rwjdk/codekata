using System;

namespace SumSquareDifferenceChallenge
{
    //The sum of the squares of the first ten natural numbers is,
    //      1^2 + 2^2 + ... + 10^2 = 385

    //The square of the sum of the first ten natural numbers is,
    //      (1 + 2 + ... + 10)^2 = 55^2 = 3025

    //Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.

    //Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

    public class Challenge
    {
        public long Execute(int x)
        {
            int sumSquares = 0;
            int squaresSum = 0;
            while (x>0)
            {
                sumSquares += Convert.ToInt32(Math.Pow(x,2));
                squaresSum += x;
                x--;
            }

            return (int)(Math.Pow(squaresSum, 2)-sumSquares);
        }
    }
}
