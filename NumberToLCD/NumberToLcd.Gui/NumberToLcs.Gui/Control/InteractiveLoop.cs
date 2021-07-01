using NumberToLcd.Gui.Interface;

namespace NumberToLcd.Gui.Control
{
    public class InteractiveLoop : IInteractiveLoop
    {
        private readonly IInputToNumberController _inputToNumberController;
        private readonly INumberWriter _numberWriter;
        private readonly IConsoleController _console;
        private readonly IInteractivLoopTerminator _interactivLoopTerminator;

        public InteractiveLoop(IInputToNumberController inputToNumberController, INumberWriter numberWriter, IConsoleController console, IInteractivLoopTerminator interactivLoopTerminator)
        {
            _inputToNumberController = inputToNumberController;
            _numberWriter = numberWriter;
            _console = console;
            _interactivLoopTerminator = interactivLoopTerminator;
        }

        public void InitiateUserInteraction()
        {
            bool exit = false;
            while (!exit)
            {
                _console.WriteLine("Syntax: 1x 2y 1234567890c [1x, 2y and c (color is optional)]");
                _console.Write("Enter number to convert to LCD (EXIT to Terminate): ");
                var input = _console.ReadLine()?.ToUpperInvariant();
                switch (input)
                {
                    case "EXIT":
                        exit = true;
                        break;
                    default:
                        var inputResult = _inputToNumberController.Parse(input);
                        if (inputResult != null)
                        {
                            _numberWriter.WriteNumbers(inputResult.Numbers, inputResult.WidthFactor, inputResult.HeightFactor, inputResult.UseColors);
                            _console.WriteLine();
                            _console.WriteLine("Press any key to try again");
                            _console.ReadKey();
                            _console.Clear();
                        }
                        else
                        {
                            _console.WriteLine("Invalid input. Press any key to try again");
                            _console.ReadKey();
                            _console.Clear();
                        }

                        break;
                }
            }

            _interactivLoopTerminator.Exit();
        }
    }
}