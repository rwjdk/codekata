using System;
using Tennis.Logic.Interface;

namespace Tennis.Control
{
    public class ConsoleTerminationController : ITerminationController
    {
        public void TerminateApp()
        {
            Environment.Exit(-1);
        }
    }
}