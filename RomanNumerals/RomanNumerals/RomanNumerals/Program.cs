using System;
using System.Globalization;
using RomanNumerals.Logic;

namespace RomanNumerals
{
    static class Program
    {
        static void Main()
        {
            //Inspiration: http://roman-numerals.info

            var numberToRomanNumeralConverter = new NumberToRomanNumeralConverter();
            var romanNumeralToNumberConverter = new RomanNumeralToNumberConverter();

            while (true)
            {
                Console.Clear();
                Console.Write("Write a number or a Roman Numeral and I will convert it for you [or write 'EXIT' to terminate]: ");
                var input = Console.ReadLine()?.ToUpperInvariant();

                if (input == "EXIT")
                {
                    Environment.Exit(0);
                }
                else if (int.TryParse(input, NumberStyles.None, CultureInfo.InvariantCulture, out int number))
                {
                    if (!numberToRomanNumeralConverter.IsValidNumber(number))
                    {
                        Console.WriteLine($"Not a valid number (Need to be between {Constants.MinimumNumber} and {Constants.MaximumNumber}). Press any key to try again");
                        Console.ReadKey();
                    }
                    else
                    {
                        var romanNumeral = numberToRomanNumeralConverter.ToRomanNumeral(number);
                        Console.WriteLine($"'{number}' as a Roman Numeral is: {romanNumeral}. Press any key to try again");
                        Console.ReadKey();
                    }
                }
                else if(romanNumeralToNumberConverter.IsValidRomanNumeral(input))
                {
                    var numberFromRomanNumeral = romanNumeralToNumberConverter.ToNumber(input);
                    Console.WriteLine($"'{input}' as a number is: {numberFromRomanNumeral}. Press any key to try again");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Invalid input (Not a number or valid roman numeral). Press any key to try again");
                    Console.ReadKey();
                }
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}