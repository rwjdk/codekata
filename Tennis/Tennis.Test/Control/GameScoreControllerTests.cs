using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace Tennis.Test.Control
{
    [TestClass]
    public class GameScoreControllerTests
    {
        private IGameScoreController _gameScoreController;

        [TestInitialize]
        public void Initialize()
        {
            _gameScoreController = DependencyInjection.Resolve<IGameScoreController>();
        }


        [TestMethod]
        public void ReturnCorrectScore()
        {
            Assert.AreEqual(new GameScore(GameScoreEnum.Score0, GameScoreEnum.Score0), _gameScoreController.GetGameScore(0, 0));
            Assert.AreEqual(new GameScore(GameScoreEnum.Score15, GameScoreEnum.Score0), _gameScoreController.GetGameScore(1, 0));
            Assert.AreEqual(new GameScore(GameScoreEnum.Score30, GameScoreEnum.Score0), _gameScoreController.GetGameScore(2, 0));
            Assert.AreEqual(new GameScore(GameScoreEnum.Score40, GameScoreEnum.Score0), _gameScoreController.GetGameScore(3, 0));
            Assert.AreEqual(new GameScore(null, null), _gameScoreController.GetGameScore(4, 0));

            Assert.AreEqual(new GameScore(GameScoreEnum.Score0, GameScoreEnum.Score0), _gameScoreController.GetGameScore(0, 0));
            Assert.AreEqual(new GameScore(GameScoreEnum.Score0, GameScoreEnum.Score15), _gameScoreController.GetGameScore(0, 1));
            Assert.AreEqual(new GameScore(GameScoreEnum.Score0, GameScoreEnum.Score30), _gameScoreController.GetGameScore(0, 2));
            Assert.AreEqual(new GameScore(GameScoreEnum.Score0, GameScoreEnum.Score40), _gameScoreController.GetGameScore(0, 3));
            Assert.AreEqual(new GameScore(null, null), _gameScoreController.GetGameScore(0, 4));

            Assert.AreEqual(new GameScore(GameScoreEnum.Score15, GameScoreEnum.Score15), _gameScoreController.GetGameScore(1, 1));
            Assert.AreEqual(new GameScore(GameScoreEnum.Score30, GameScoreEnum.Score30), _gameScoreController.GetGameScore(2, 2));
            Assert.AreEqual(new GameScore(GameScoreEnum.Deuce, GameScoreEnum.Deuce), _gameScoreController.GetGameScore(3, 3));
            Assert.AreEqual(new GameScore(GameScoreEnum.Deuce, GameScoreEnum.Deuce), _gameScoreController.GetGameScore(4, 4));
            Assert.AreEqual(new GameScore(GameScoreEnum.Deuce, GameScoreEnum.Deuce), _gameScoreController.GetGameScore(5, 5));

            Assert.AreEqual(new GameScore(null, GameScoreEnum.Advantage), _gameScoreController.GetGameScore(3, 4));
            Assert.AreEqual(new GameScore(GameScoreEnum.Advantage, null), _gameScoreController.GetGameScore(4, 3));
            Assert.AreEqual(new GameScore(null, null), _gameScoreController.GetGameScore(5, 3));
            Assert.AreEqual(new GameScore(null, null), _gameScoreController.GetGameScore(3, 5));
        }
    }
}