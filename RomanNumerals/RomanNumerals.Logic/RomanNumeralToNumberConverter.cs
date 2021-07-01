using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RomanNumerals.Logic
{
    public class RomanNumeralToNumberConverter
    {
        private readonly Dictionary<string, int> _allValidRomanNumerals;

        public RomanNumeralToNumberConverter()
        {
            _allValidRomanNumerals = GetAllRomanNumerals();
        }

        public int ToNumber(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }

            if (!IsValidRomanNumeral(input))
            { 
                throw new ArgumentOutOfRangeException(nameof(input), "Input is not a valid roman numeral");
            }

            return _allValidRomanNumerals[input.ToUpperInvariant()];
        }

        private Dictionary<string, int> GetAllRomanNumerals()
        {
            var result = new Dictionary<string, int>();
            var converter = new NumberToRomanNumeralConverter();
            for (int i = Constants.MinimumNumber; i <= Constants.MaximumNumber; i++)
            {
                result.Add(converter.ToRomanNumeral(i), i);
            }
            return result;
        }

        public bool IsValidRomanNumeral(string input)
        {
            return _allValidRomanNumerals.ContainsKey(input.ToUpperInvariant());
        }
    }
}