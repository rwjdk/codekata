using System;
using System.Linq;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace Tennis.Model
{
    public class ConsoleNumberOfSetsUserInput : ConsoleUserInput, INumberOfSetsUserInput
    {
        private readonly INumberOfSetsController _numberOfSetsController;

        public ConsoleNumberOfSetsUserInput(INumberOfSetsController numberOfSetsController, string rawInput) : base(rawInput)
        {
            _numberOfSetsController = numberOfSetsController;
        }

        NumberOfSetsUserInput INumberOfSetsUserInput.Input
        {
            get
            {
                if (IsExitKeyword())
                {
                    return NumberOfSetsUserInput.Exit;
                }

                if (TryParseToInteger(out int result) && _numberOfSetsController.ValidNumberOfSets.Contains(result))
                {
                    return NumberOfSetsUserInput.ValidInput;
                }
                
                return NumberOfSetsUserInput.InvalidInput;
            }
        }

        public int InputAsInteger
        {
            get
            {
                if (TryParseToInteger(out var result))
                {
                    return result;
                }
                throw new InvalidCastException($"Input '{RawInput}'can't be converted to an integer");
            }
        }
    }
}