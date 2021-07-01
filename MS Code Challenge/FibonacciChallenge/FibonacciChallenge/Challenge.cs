using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciChallenge
{
    public class Challenge
    {
        /*
         * Write a method that returns any given number in the Fibonnacci sequence.
         * 0,1,1,2,3,5,8,13,21...
         */
		 
        public long Fib(int n)
        {
            List<int> sequence = new List<int>()
            {
                0,
                1
            };

            int current = sequence.Sum();
            int counter = 0;
            while (counter < n)
            {
                sequence.Add(current);
                current = current + sequence[sequence.Count - 2];
                counter++;
            }

            return sequence[n];
        }
    }
}
