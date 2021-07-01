using System;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace Tennis.Test.Fakes
{
    public class TestGuiController : IGuiController
    {
        private readonly NumberOfSetsUserInput _numberOfSetsUserInput;
        private readonly int _numberOfSets;

        public TestGuiController(NumberOfSetsUserInput numberOfSetsUserInput, int numberOfSets)
        {
            _numberOfSetsUserInput = numberOfSetsUserInput;
            _numberOfSets = numberOfSets;
        }

        public void PrintMatchStatus(IMatch match)
        {
            throw new NotImplementedException();
        }

        public void DisplayFinalResult(IMatch match)
        {
            throw new NotImplementedException();
        }

        public INumberOfSetsUserInput AskForNumberOfSets()
        {
            return new TestNumberOfSetsUserInput(_numberOfSetsUserInput, _numberOfSets);
        }

        public void DisplayInvalidNumberOfSets(INumberOfSetsUserInput userInput)
        {
            //Empty
        }

        public void DisplayInvalidInputMessage()
        {
            throw new NotImplementedException();
        }

        public Player? AskForWinnerOfNextGame()
        {
            throw new NotImplementedException();
        }

        public event Action ExitRequested;
    }
}