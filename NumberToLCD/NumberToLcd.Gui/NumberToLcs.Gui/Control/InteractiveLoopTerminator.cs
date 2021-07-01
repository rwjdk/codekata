using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using NumberToLcd.Gui.Interface;

namespace NumberToLcd.Gui.Control
{
    [ExcludeFromCodeCoverage]
    [UsedImplicitly]
    public class InteractiveLoopTerminator : IInteractivLoopTerminator
    {
        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}