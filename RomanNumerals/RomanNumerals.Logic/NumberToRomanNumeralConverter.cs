using System;
using System.Linq;

namespace RomanNumerals.Logic
{
    public class NumberToRomanNumeralConverter
    {
        private readonly NumberGroupToRomanNumeralConverter _oneGroup;
        private readonly NumberGroupToRomanNumeralConverter _tenGroup;
        private readonly NumberGroupToRomanNumeralConverter _hundredGroup;

        public NumberToRomanNumeralConverter()
        {
            _oneGroup = NumberGroupToRomanNumeralConverter.GenerateOnesGroup();
            _tenGroup = NumberGroupToRomanNumeralConverter.GenerateTensGroup();
            _hundredGroup = NumberGroupToRomanNumeralConverter.GenerateHundresGroup();
        }

        public string ToRomanNumeral(int input)
        {
            if (!IsValidNumber(input))
            {
                throw new ArgumentOutOfRangeException(nameof(input), $"Number should be between {Constants.MinimumNumber} and {Constants.MaximumNumber}");
            }

            string result = string.Empty;
            while (input >= 1000)
            {
                result += Constants.SymbolFor1000;
                input -= 1000;
            }

            var inputSplitIntoindividualNumbers = input.ToString().ToCharArray().Select(x => Convert.ToInt32(x.ToString())).ToList();

            switch (inputSplitIntoindividualNumbers.Count)
            {
                case 1:
                    return result + 
                        _oneGroup.GetNumberGroupValue(inputSplitIntoindividualNumbers[0]);
                case 2:
                    return result +
                        _tenGroup.GetNumberGroupValue(inputSplitIntoindividualNumbers[0]) +
                        _oneGroup.GetNumberGroupValue(inputSplitIntoindividualNumbers[1]);
                default: //3
                    return result +
                        _hundredGroup.GetNumberGroupValue(inputSplitIntoindividualNumbers[0]) +
                        _tenGroup.GetNumberGroupValue(inputSplitIntoindividualNumbers[1]) +
                        _oneGroup.GetNumberGroupValue(inputSplitIntoindividualNumbers[2]);
            }
        }

        public bool IsValidNumber(int input)
        {
            return input >= Constants.MinimumNumber && input <= Constants.MaximumNumber;
        }
    }
}