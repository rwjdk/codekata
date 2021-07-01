using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexChallenge
{
    public class Challenge
    {
        /* Regex Challenge
         * 
         * In this challenge, you will receive just one input parameter for your challenge: a random chapter of Charles Dickens' "Great Expectations".
         * 
         * You need to identify all punctutation characters except for periods (dots). Your method should return the number of punctuation characters except for periods as an integer.
         * 
         * Example: If the input string would be the line below, then the result should be 10.
         * 
         *          `O! Don't cut my throat, sir,' I pleaded in terror. `Pray don't do it, sir.'
         *          ^ ^    ^               ^    ^^                      ^        ^       ^     ^
         *          1 2    3               4    56                      7        8       9     10
         * 
         * The return type of your method must be System.Int32.
         * 
         * Good luck!
         */

        public int Execute(string chapter)
        {
            int counter = 0;
            foreach (var @char in chapter)
            {
                var isLetterOrDigit = Char.IsLetterOrDigit(@char);
                var isSeparator = Char.IsSeparator(@char);
                var isPeriod = @char == '.';
                var isWhiteSpace = Char.IsWhiteSpace(@char);

                if (!isLetterOrDigit && !isSeparator && !isPeriod && !isWhiteSpace)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
