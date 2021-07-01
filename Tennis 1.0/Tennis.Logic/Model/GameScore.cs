using System;
using System.Collections.Generic;
using Tennis.Logic.Interface;

namespace Tennis.Logic.Model
{
    public class GameScore : IEquatable<IGameScore>, IGameScore
    {
        private readonly Dictionary<Player, GameScoreEnum?> _gameScores;

        public GameScore(GameScoreEnum? player1Score, GameScoreEnum? player2Score)
        {
            _gameScores = new Dictionary<Player, GameScoreEnum?>
            {
                {Player.Player1, player1Score},
                {Player.Player2, player2Score}
            };
        }

        public GameScoreEnum? GetScoreForPlayer(Player player)
        {
            if (!_gameScores.ContainsKey(player))
            {
                throw new ArgumentOutOfRangeException(nameof(player));
            }
            return _gameScores[player];
        }

        public bool Equals(IGameScore other)
        {
            return GetScoreForPlayer(Player.Player1) == other?.GetScoreForPlayer(Player.Player1) && GetScoreForPlayer(Player.Player2) == other?.GetScoreForPlayer(Player.Player2);
        }

        public override bool Equals(object obj)
        {
            return Equals((IGameScore) obj);
        }

        public override int GetHashCode()
        {
            return (_gameScores != null ? _gameScores.GetHashCode() : 0);
        }
    }
}