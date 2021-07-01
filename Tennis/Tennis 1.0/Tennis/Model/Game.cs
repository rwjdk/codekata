using System;
using System.Collections.Generic;
using Tennis.Control;
using Tennis.Interface;

namespace Tennis.Model
{
    internal class Game
    {
        private readonly GameController _gameController;
        private readonly Dictionary<Player, int> _points;
        public Player? Winner { get; private set; }

        public Game(GameController gameController, IPlayerDictionaryHelper playerDictionaryHelper)
        {
            _gameController = gameController;
            _points = playerDictionaryHelper.CreateEmptyPlayerDictionary();
        }

        public void RegisterPoint(Player playerWhoWonThePoint)
        {
            _points[playerWhoWonThePoint]++;

            if (_gameController.IsWinningScenario(_points[Player.Player1], _points[Player.Player2]))
            {
                Winner = playerWhoWonThePoint;
            }
        }

        public GameScore? GetPointStatusForPlayer(Player player)
        {
            var player1Points = _points[Player.Player1];
            var player2Points = _points[Player.Player2];
            return _gameController.GetPointStatus(player1Points, player2Points)[player];
        }
    }
}