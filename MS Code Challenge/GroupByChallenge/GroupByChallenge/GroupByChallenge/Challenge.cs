using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupByChallenge
{
    public class Challenge
    {
        /* Group By Challenge
         * 
         * In this challenge, you will receive an array of objects (POCOs) as the input for your method.
         * 
         * You must group the objects by their types and return a dictionary with the type as the key and the number of occurrences of each type as the value.
         * 
         * Hint: LINQ is your friend!
         * 
         * Good luck!
         */

        public Dictionary<Type, int> Execute(object[] input)
        {
            var result = new Dictionary<Type, int>();
            IEnumerable<IGrouping<Type, object>> groups = input.GroupBy(x => x.GetType());
            foreach (var @group in groups)
            {
                var type = @group.Key;
                if (result.ContainsKey(type))
                {
                    result[type] += group.Count();
                }
                else
                {
                    result.Add(type, group.Count());
                }
            }
            return result;
        }
    }
}
