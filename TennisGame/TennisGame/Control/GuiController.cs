using System;
using Tennis.Logic.Interface;
using Player = Tennis.Logic.Model.Player;

namespace TennisGame.Control
{
    public class GuiController : IGuiController
    {
        public int NumberOfSetSelected { get; set; }


        public void PrintMatchStatus(IMatch match)
        {
            //Empty
        }

        public void DisplayFinalResult(IMatch match)
        {
            //Empty
        }

        public INumberOfSetsUserInput AskForNumberOfSets()
        {
            return new NumberOfSetsUserInput(NumberOfSetSelected);
        }

        public void DisplayInvalidNumberOfSets(INumberOfSetsUserInput userInput)
        {
            //Empty
        }

        public void DisplayInvalidInputMessage()
        {
            //Empty
        }

        public Player? AskForWinnerOfNextGame()
        {
            throw new NotImplementedException();
        }

        public event Action ExitRequested;
    }
}