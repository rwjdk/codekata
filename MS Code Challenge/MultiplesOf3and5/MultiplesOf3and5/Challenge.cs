using System;

namespace MultiplesOf3and5
{
    //If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    //Find the sum of all the multiples of 3 or 5 below X.

    public class Challenge
    {
        public int Execute(int x)
        {
            int result = 0;
            for (int i = 0; i < x; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    result += i;
                }
            }

            return result;
        }
    }
}