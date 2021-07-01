using System.Globalization;

namespace Tennis.Model
{
    public class ConsoleUserInput
    {
        protected readonly string RawInput;

        protected bool IsExitKeyword()
        {
            return RawInput?.ToUpperInvariant() == "EXIT";
        }

        protected bool IsAutoKeyword()
        {
            return RawInput?.ToUpperInvariant() == "AUTO";
        }

        protected ConsoleUserInput(string rawInput)
        {
            RawInput = rawInput;
        }

        protected bool TryParseToInteger(out int result)
        {
            return int.TryParse(RawInput, NumberStyles.None, CultureInfo.InvariantCulture, out result);
        }
    }
}