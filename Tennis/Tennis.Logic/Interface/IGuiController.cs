using System;
using Tennis.Logic.Model;

namespace Tennis.Logic.Interface
{
    public interface IGuiController
    {
        void PrintMatchStatus(IMatch match);
        void DisplayFinalResult(IMatch match);
        INumberOfSetsUserInput AskForNumberOfSets();
        void DisplayInvalidNumberOfSets(INumberOfSetsUserInput userInput);
        void DisplayInvalidInputMessage();
        Player? AskForWinnerOfNextGame();
        event Action ExitRequested;
    }
}