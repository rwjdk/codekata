using System;
using System.Collections.Generic;
using System.Linq;
using NumberToLcd.Gui.Interface;
using NumberToLcd.Logic.Model;

namespace NumberToLcd.Gui.Control
{
    public class NumberWriter : INumberWriter
    {
        public NumberWriter(IConsoleController console)
        {
            Console = console;
        }

        public IConsoleController Console { get; }

        public void WriteNumbers(List<Number> numbers, int widthFactor = 1, int heightFactor = 1, bool useColors = false)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (widthFactor < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(widthFactor), "Width-Factor should be 1 or more");
            }

            if (heightFactor < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(heightFactor), "Height-Factor should be 1 or more");
            }

            //Take care of word-wrap
            int widthOfNumber = widthFactor + 2;
            var windowWidth = Console.WindowWidth;
            int numberOfLcdNumbersThatCanFitVertically = (windowWidth / widthOfNumber)-1;
            int numbersToSkip = 0;
            while (numbersToSkip < numbers.Count)
            {
                var numbersAtAddToLine = numbers.Skip(numbersToSkip).Take(numberOfLcdNumbersThatCanFitVertically).ToList();
                numbersToSkip += numbersAtAddToLine.Count;

                WriteNumberSection(numbersAtAddToLine, NumberSection.Top, widthFactor, useColors);

                for (int i = 0; i < heightFactor - 1; i++)
                {
                    WriteNumberSection(numbersAtAddToLine, NumberSection.ScaledMiddleUpper, widthFactor, useColors);
                }

                WriteNumberSection(numbersAtAddToLine, NumberSection.Middle, widthFactor, useColors);

                for (int i = 0; i < heightFactor - 1; i++)
                {
                    WriteNumberSection(numbersAtAddToLine, NumberSection.ScaledMiddleLower, widthFactor, useColors);
                }

                WriteNumberSection(numbersAtAddToLine, NumberSection.Bottom, widthFactor, useColors);
            }

            if (useColors)
            {
                Console.ResetColors();
            }
        }

        private void WriteNumberSection(List<Number> numbers, NumberSection section, int widthFactor, bool useColors)
        {
            foreach (var number in numbers)
            {
                if (useColors)
                {
                    Console.SetConsoleForeColor((ConsoleColor) number.Value);
                }
                Console.Write(number.GetNumberSection(section, widthFactor));
            }
            Console.WriteLine();
        }
    }
}