using System.Collections.Generic;
using NumberToLcd.Logic.Model;

namespace NumberToLcd.Gui.Interface
{
    public interface INumberWriter
    {
        IConsoleController Console { get; }
        void WriteNumbers(List<Number> numbers, int widthFactor = 1, int heightFactor = 1, bool useColors = false);
    }
}