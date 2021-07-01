using Tennis.Logic.Interface;

namespace TennisGame.Control
{
    public class NumberOfSetsUserInput : INumberOfSetsUserInput
    {
        public NumberOfSetsUserInput(int numberOfsets)
        {
            InputAsInteger = numberOfsets;
        }

        public Tennis.Logic.Model.NumberOfSetsUserInput Input
        {
            get
            {
                if (InputAsInteger != 0)
                {
                    return Tennis.Logic.Model.NumberOfSetsUserInput.ValidInput;
                }
                return Tennis.Logic.Model.NumberOfSetsUserInput.InvalidInput;
            }
        }

        public int InputAsInteger { get; }
    }
}