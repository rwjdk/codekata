using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace Tennis.Test.Model
{
    [TestClass]
    public class GameScoreTests
    {
        [TestMethod]
        public void GetGameScoreEqual()
        {
            IGameScore gameScore = new GameScore(GameScoreEnum.Score0, GameScoreEnum.Score0);
            Assert.AreEqual(GameScoreEnum.Score0, gameScore.GetScoreForPlayer(Player.Player1));
        }

        [TestMethod]
        public void GetGameScoreHashCode()
        {
            IGameScore gameScore1 = new GameScore(GameScoreEnum.Score0, GameScoreEnum.Score0);
            IGameScore gameScore2 = new GameScore(GameScoreEnum.Score0, GameScoreEnum.Score0);
            Assert.IsFalse(gameScore1.GetHashCode() == gameScore2.GetHashCode());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [ExcludeFromCodeCoverage]
        public void GetGameScoreFromInvalidPlayerThrowException()
        {
            IGameScore gameScore = new GameScore(GameScoreEnum.Score0, GameScoreEnum.Score0);
            gameScore.GetScoreForPlayer((Player) 666);
        }
    }
}