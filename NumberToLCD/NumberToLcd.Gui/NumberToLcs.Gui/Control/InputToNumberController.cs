using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using NumberToLcd.Gui.Interface;
using NumberToLcd.Gui.Model;
using NumberToLcd.Logic.Model;

namespace NumberToLcd.Gui.Control
{
    [UsedImplicitly]
    public class InputToNumberController : IInputToNumberController
    {
        private List<Number> TransformToNumberObjects(BigInteger number)
        {
            var result = new List<Number>();
            var charactersInNumber = number.ToString().ToCharArray();
            foreach (var character in charactersInNumber)
            {
                result.Add(new Number(Convert.ToInt32(character.ToString())));
            }
            return result;
        }

        public InputResult Parse(string input)
        {
            int widthFactor = 1;
            int heightFactor = 1;
            string pattern = "(?<width>.\\d*X)*(?<height>\\d*Y)*(?<input>[0-9]*)(?<useColor>[C]*)";
            var match = Regex.Match(input.Replace(" ",""), pattern, RegexOptions.IgnoreCase);
            var widthMatch = match.Groups["width"].Value;
            var heightMatch = match.Groups["height"].Value;
            var inputMatch = match.Groups["input"].Value;
            var colorMatch = match.Groups["useColor"].Value;

            if (!string.IsNullOrWhiteSpace(widthMatch))
            {
                widthFactor = Convert.ToInt32(widthMatch.Substring(0, widthMatch.Length - 1));
            }

            if (!string.IsNullOrWhiteSpace(heightMatch))
            {
                heightFactor = Convert.ToInt32(heightMatch.Substring(0, heightMatch.Length - 1));
            }

            var useColors = !string.IsNullOrWhiteSpace(colorMatch);

            var isANumber = BigInteger.TryParse(inputMatch, NumberStyles.None, CultureInfo.InvariantCulture, out var number);
            if (isANumber)
            {
                var numbers = TransformToNumberObjects(number);
                return new InputResult(numbers, widthFactor, heightFactor, useColors);
            }

            return null;
        }
    }
}