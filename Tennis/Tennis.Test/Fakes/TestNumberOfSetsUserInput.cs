using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace Tennis.Test.Fakes
{
    public class TestNumberOfSetsUserInput : INumberOfSetsUserInput
    {
        public TestNumberOfSetsUserInput(NumberOfSetsUserInput input, int inputAsInteger)
        {
            Input = input;
            InputAsInteger = inputAsInteger;
        }

        public NumberOfSetsUserInput Input { get; }
        public int InputAsInteger { get; }
    }
}