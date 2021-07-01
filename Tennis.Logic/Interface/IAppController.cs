using System;
using Tennis.Logic.Model;

namespace Tennis.Logic.Interface
{
    public interface IAppController
    {
        void AskForNumberOfSets();
        bool IsNumberOfSetsNotDefined();
        void StartMatch();
        bool HaveNotYetFoundItsWinner();
        event Action<IMatch> GameStatusChanged;
        event Action<IMatch> MatchIsOver;
        void SetWinnerOfNextGame(Player player);
    }
}