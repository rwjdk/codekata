using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using NumberToLcd.Gui.Interface;

namespace NumberToLcd.Gui.Control
{
    [ExcludeFromCodeCoverage]
    [UsedImplicitly]
    public class ConsoleController : IConsoleController
    {
        public void SetConsoleForeColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public void Write(string message = null)
        {
            Console.Write(message);
        }

        public void WriteLine(string message = null)
        {
            Console.WriteLine(message);
        }

        public void ReadKey()
        {
            Console.ReadKey();
        }

        public void Clear()
        {
            Console.Clear();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void ResetColors()
        {
            Console.ResetColor();
        }

        public int WindowWidth => Console.WindowWidth;
    }
}