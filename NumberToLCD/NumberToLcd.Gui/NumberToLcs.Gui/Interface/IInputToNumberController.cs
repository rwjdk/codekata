using NumberToLcd.Gui.Model;

namespace NumberToLcd.Gui.Interface
{
    public interface IInputToNumberController
    {
        InputResult Parse(string input);
    }
}