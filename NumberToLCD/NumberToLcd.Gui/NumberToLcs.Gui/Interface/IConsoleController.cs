using System;

namespace NumberToLcd.Gui.Interface
{
    public interface IConsoleController
    {
        void SetConsoleForeColor(ConsoleColor color);
        void Write(string message = null);
        void WriteLine(string message = null);
        void ReadKey();
        void Clear();
        string ReadLine();
        int WindowWidth { get; }
        void ResetColors();
    }
}