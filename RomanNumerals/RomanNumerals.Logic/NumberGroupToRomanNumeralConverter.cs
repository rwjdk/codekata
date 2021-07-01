using System;

namespace RomanNumerals.Logic
{
    public class NumberGroupToRomanNumeralConverter
    {
        public int Factor { get; }
        private readonly char _symbolForOneInGroup;
        private readonly char _symbolForFiveInGroup;
        private readonly char _symbolForTenInGroup;

        private NumberGroupToRomanNumeralConverter(char symbolForOneInGroup, char symbolForFiveInGroup, char symbolForTenInGroup, int factor)
        {
            Factor = factor;
            _symbolForOneInGroup = symbolForOneInGroup;
            _symbolForFiveInGroup = symbolForFiveInGroup;
            _symbolForTenInGroup = symbolForTenInGroup;
        }

        public string GetNumberGroupValue(int numberInGroup)
        {
            switch (numberInGroup)
            {
                case 0:
                    return string.Empty;
                case 1:
                case 2:
                case 3:
                    return string.Empty.PadLeft(numberInGroup, _symbolForOneInGroup);
                case 4:
                    return _symbolForOneInGroup + _symbolForFiveInGroup.ToString();
                case 5:
                case 6:
                case 7:
                case 8:
                    return _symbolForFiveInGroup + string.Empty.PadLeft(numberInGroup - 5, _symbolForOneInGroup);
                case 9:
                    return _symbolForOneInGroup + _symbolForTenInGroup.ToString();
                default:
                    throw new ArgumentOutOfRangeException(nameof(numberInGroup), "Can only be between 0 and 9");
            }
        }

        public static NumberGroupToRomanNumeralConverter GenerateOnesGroup()
        {
            return new NumberGroupToRomanNumeralConverter(Constants.SymbolFor1, Constants.SymbolFor5, Constants.SymbolFor10, 1);
        }

        public static NumberGroupToRomanNumeralConverter GenerateTensGroup()
        {
            return new NumberGroupToRomanNumeralConverter(Constants.SymbolFor10, Constants.SymbolFor50, Constants.SymbolFor100, 10);
        }

        public static NumberGroupToRomanNumeralConverter GenerateHundresGroup()
        {
            return new NumberGroupToRomanNumeralConverter(Constants.SymbolFor100, Constants.SymbolFor500, Constants.SymbolFor1000, 100);
        }
        
    }
}