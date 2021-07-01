﻿using Tennis.Logic.Interface;

namespace Tennis.Logic.Model
{
    public class Game : IGame
    {
        private readonly IGameScoreController _gameScoreController;
        private readonly IValueTracker _pointTracker;
        public Player? Winner { get; private set; }

        public Game(IGameScoreController gameScoreController)
        {
            _gameScoreController = gameScoreController;
            _pointTracker = new ValueTracker();
        }

        public void RegisterPoint(Player playerWhoWonThePoint)
        {
            _pointTracker.TrackPoint(playerWhoWonThePoint);

            if (_gameScoreController.IsWinningScenario(_pointTracker.GetPoint(Player.Player1), _pointTracker.GetPoint(Player.Player2)))
            {
                Winner = playerWhoWonThePoint;
            }
        }

        public IGameScore GetGameScore()
        {
            var player1Points = _pointTracker.GetPoint(Player.Player1);
            var player2Points = _pointTracker.GetPoint(Player.Player2);
            return _gameScoreController.GetGameScore(player1Points, player2Points);
        }

        public void Reset()
        {
            _pointTracker.Reset();
            Winner = null;
        }
    }
}