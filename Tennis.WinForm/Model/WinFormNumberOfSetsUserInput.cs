using System;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace Tennis.WinForm.Model
{
    public class WinFormNumberOfSetsUserInput : INumberOfSetsUserInput
    {
        private readonly NumberOfSetsUserInput _input;
        private readonly int _numberOfSets;

        public WinFormNumberOfSetsUserInput(NumberOfSetsUserInput input)
        {
            _input = input;
        }

        public WinFormNumberOfSetsUserInput(int numberOfSets)
        {
            _numberOfSets = numberOfSets;
            _input = NumberOfSetsUserInput.ValidInput;

        }

        NumberOfSetsUserInput INumberOfSetsUserInput.Input => _input;

        public int InputAsInteger
        {
            get
            {
                if (_input == NumberOfSetsUserInput.ValidInput)
                {
                    return _numberOfSets;
                }
                throw new InvalidCastException($"Input can't be converted to an integer");
            }
        }
    }
}