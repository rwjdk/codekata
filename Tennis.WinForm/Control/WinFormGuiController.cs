using System;
using System.Windows.Forms;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;
using Tennis.WinForm.Model;
using Tennis.WinForm.View;

namespace Tennis.WinForm.Control
{
    public class WinFormGuiController : IGuiController
    {
        public event Action ExitRequested;

        public void PrintMatchStatus(IMatch match)
        {
            throw new NotImplementedException();
        }

        public void DisplayFinalResult(IMatch match)
        {
            switch (match.Winner)
            {
                case Player.Player1:
                    MessageBox.Show("Player 1 won the match");
                    break;
                case Player.Player2:
                    MessageBox.Show("Player 2 won the match");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public INumberOfSetsUserInput AskForNumberOfSets()
        {
            var formNumberOfSets = new FormNumberOfSets();
            var dialogResult = formNumberOfSets.ShowDialog();

            switch (dialogResult)
            {
                case DialogResult.OK:
                    return new WinFormNumberOfSetsUserInput(formNumberOfSets.NumberOfSets);
                case DialogResult.Abort:
                    return new WinFormNumberOfSetsUserInput(NumberOfSetsUserInput.Exit);
                default:
                    return new WinFormNumberOfSetsUserInput(NumberOfSetsUserInput.InvalidInput);
            }
        }

        public void DisplayInvalidNumberOfSets(INumberOfSetsUserInput userInput)
        {
            MessageBox.Show(@"Invalid number of sets");
        }

        public void DisplayInvalidInputMessage()
        {
            throw new NotImplementedException();
        }

        public Player? AskForWinnerOfNextGame()
        {
            throw new NotImplementedException();
        }
    }
}