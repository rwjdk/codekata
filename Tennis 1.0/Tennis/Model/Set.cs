using System;
using System.Collections.Generic;
using Tennis.Control;
using Tennis.Interface;

namespace Tennis.Model
{
    internal class Set
    {
        private readonly SetController _setController;
        private readonly Dictionary<Player, int> _games;
        public Player? Winner { get; private set; }

        public Set(SetController setController, IPlayerDictionaryHelper playerDictionaryHelper)
        {
            _setController = setController;
            _games = playerDictionaryHelper.CreateEmptyPlayerDictionary();
        }

        public void RegisterGame(Game game)
        {
            if (!game.Winner.HasValue)
            {
                throw new InvalidOperationException("Can't register a game that is not yet won");
            }

            var playerWhoWonTheGame = game.Winner.Value;
            _games[playerWhoWonTheGame]++;

            if (_setController.IsWinningScenario(_games[Player.Player1], _games[Player.Player2]))
            {
                Winner = playerWhoWonTheGame;
            }
        }

        public int GetWonGames(Player player)
        {
            return _games[player];
        }
    }
}