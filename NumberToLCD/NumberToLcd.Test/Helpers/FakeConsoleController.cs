using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using NumberToLcd.Gui.Interface;

namespace NumberToLcd.Test.Helpers
{
    [ExcludeFromCodeCoverage]
    public class FakeConsoleController : IConsoleController
    {
        private int _nextReadLine;
        public string[] ReadLineReplies { get; }
        public bool ColorSet { get; private set; }
        public StringBuilder FullMessageGivenToConsole { get; }

        public FakeConsoleController()
        {
            _nextReadLine = 0;
            FullMessageGivenToConsole = new StringBuilder();
        }

        public FakeConsoleController(params string[] readLineReplies) : this()
        {
            ReadLineReplies = readLineReplies;
        }

        public void SetConsoleForeColor(ConsoleColor color)
        {
            ColorSet = true;
        }

        public void Write(string message = null)
        {
            if (message != null)
            {
                FullMessageGivenToConsole.Append(message);
            }
        }

        public void WriteLine(string message = null)
        {
            if (message != null)
            {
                FullMessageGivenToConsole.Append(message + Environment.NewLine);
            }
        }

        public void ReadKey()
        {
            //Empty
        }

        public void Clear()
        {
            FullMessageGivenToConsole.Clear();
        }

        public string ReadLine()
        {
            if (ReadLineReplies.Length == 0 || _nextReadLine >= ReadLineReplies.Length)
            {
                return "EXIT";
            }

            var reply = ReadLineReplies[_nextReadLine];
            _nextReadLine++;
            return reply;
        }
        
        public void ResetColors()
        {
            //Empty
        }

        public int WindowWidth => int.MaxValue;
    }
}