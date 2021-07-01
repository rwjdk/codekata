using System;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace Tennis.Logic.Control
{
    public sealed class AppController : IAppController
    {
        private readonly INumberOfSetsController _numberOfSetsController;
        private readonly IMatchController _matchController;
        private readonly IGuiController _guiController;
        private readonly ITerminationController _iTerminationController;
        private IMatch _match;
        public event Action<IMatch> GameStatusChanged;
        public event Action<IMatch> MatchIsOver;
        
        public AppController(INumberOfSetsController numberOfSetsController, IMatchController matchController, IGuiController guiController, ITerminationController iTerminationController)
        {
            _numberOfSetsController = numberOfSetsController;
            _matchController = matchController;
            _guiController = guiController;
            _iTerminationController = iTerminationController;
        }

        public void AskForNumberOfSets()
        {
            var userInput = _guiController.AskForNumberOfSets();
            switch (userInput.Input)
            {
                case NumberOfSetsUserInput.ValidInput:
                    _numberOfSetsController.NumberOfSets = userInput.InputAsInteger;
                    break;
                case NumberOfSetsUserInput.InvalidInput:
                    _guiController.DisplayInvalidNumberOfSets(userInput);
                    break;
                case NumberOfSetsUserInput.Exit:
                    _iTerminationController.TerminateApp();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public bool IsNumberOfSetsNotDefined()
        {
            return _numberOfSetsController.IsNotDefined();
        }

        public void StartMatch()
        {
            _match = _matchController.CreateMatch(_numberOfSetsController.NumberOfSets);
            GameStatusChanged?.Invoke(_match);
        }

        public bool HaveNotYetFoundItsWinner()
        {
            if (!_match.Winner.HasValue)
            {
                return true;
            }

            MatchIsOver?.Invoke(_match);
            return false;
        }

        public void SetWinnerOfNextGame(Player player)
        {
            _match.RegisterPoint(player);
            GameStatusChanged?.Invoke(_match);
        }
    }
}