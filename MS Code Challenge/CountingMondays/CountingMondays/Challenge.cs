using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingMondays
{
    public class Challenge
    {
        //You are given the following information:
        //    1 Jan 1900 was a Monday.
        //    Thirty days has September,
        //    April, June and November.
        //    All the rest have thirty-one,
        //    Saving February alone,
        //    Which has twenty-eight, rain or shine.
        //    And on leap years, twenty-nine.
        //    A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.

        //How many Mondays fell on the first of the month from year x to y?

        public int Execute(int x, int y)
        {
            DateTime startDate = new DateTime(x,1,1);
            DateTime endDate = new DateTime(y, 12, 31);

            int result = 0;
            while (startDate <= endDate)
            {
                if (startDate.Day == 1 && startDate.DayOfWeek == DayOfWeek.Monday)
                {
                    result++;
                }
                startDate = startDate.AddDays(1);
            }
            return result;
        }
    }
}
