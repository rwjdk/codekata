using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace Tennis.Model
{
    public class ConsoleMatchStatusUserInput : ConsoleUserInput, IMatchStatusUserInput
    {
        public ConsoleMatchStatusUserInput(string rawInput) : base(rawInput)
        {
            //Empty
        }

        public MatchStatusUserInput Input
        {
            get
            {
                if (IsAutoKeyword())
                {
                    return MatchStatusUserInput.Auto;
                }

                if (IsExitKeyword())
                {
                    return MatchStatusUserInput.Exit;
                }

                if (RawInput == "1")
                {
                    return MatchStatusUserInput.Player1;
                }

                if (RawInput == "2")
                {
                    return MatchStatusUserInput.Player2;
                }

                return MatchStatusUserInput.InvalidInput;
            }
        }
    }
}