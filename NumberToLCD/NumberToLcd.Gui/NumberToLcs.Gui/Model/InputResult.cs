using System.Collections.Generic;
using NumberToLcd.Logic.Model;

namespace NumberToLcd.Gui.Model
{
    public class InputResult
    {
        public int WidthFactor { get; }
        public int HeightFactor { get; }
        public List<Number> Numbers { get; }
        public bool UseColors { get; }

        public InputResult(List<Number> numbers, int widthFactor, int heightFactor, bool useColors)
        {
            WidthFactor = widthFactor;
            HeightFactor = heightFactor;
            Numbers = numbers;
            UseColors = useColors;
        }
    }
}