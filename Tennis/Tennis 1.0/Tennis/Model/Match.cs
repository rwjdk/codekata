using System;
using System.Collections.Generic;
using Tennis.Control;

namespace Tennis.Model
{
    internal class Match
    {
        private readonly int _numberOfSets;
        private readonly GameController _gameController;
        public Game CurrentGame { get; private set; }
        public List<Set> Sets { get; }
        private int _currentSetNumber;

        public int CurrentSetNumber => _currentSetNumber;

        public int NumberOfSets => _numberOfSets;

        public Player? Winner { get; set; }

        public Match(int numberOfSets, GameController gameController, SetController setController)
        {
            if (numberOfSets < 0 || numberOfSets > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfSets), "Number of set need to between 1 and 5");
            }

            _currentSetNumber = 1;
            _numberOfSets = numberOfSets;
            _gameController = gameController;

            CurrentGame = _gameController.CreateNewGame();
            Sets = setController.CreateSets(numberOfSets);

        }

        public void RegisterPoint(Player playerWhoWonThePoint)
        {
            CurrentGame.RegisterPoint(playerWhoWonThePoint);
            if (!CurrentGame.Winner.HasValue)
            {
                return;
            }

            //Game is over. Register and reset
            var currentSet = Sets[_currentSetNumber - 1];
            currentSet.RegisterGame(CurrentGame);
            CurrentGame = _gameController.CreateNewGame();

            if (!currentSet.Winner.HasValue)
            {
                return;
            }

            //Test if all sets have been played (Is match over)
            if (_currentSetNumber == _numberOfSets)
            {
                Winner = playerWhoWonThePoint;
            }
            else
            {
                _currentSetNumber++;
            }
        }
    }
}