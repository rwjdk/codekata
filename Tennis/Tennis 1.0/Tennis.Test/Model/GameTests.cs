using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tennis.Logic.Control;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace Tennis.Test.Model
{
    [TestClass]
    public class GameTests
    {
        private IGameRulesController _gameRulesController;
        private IGameScoreController _gameScoreController;

        [TestInitialize]
        public void Setup()
        {
            _gameRulesController = new GameRulesController();
            _gameScoreController = new GameScoreController(_gameRulesController);
        }

        [TestMethod]
        public void NewGameTest()
        {
            IGame game = new Game(_gameRulesController, _gameScoreController);
            Assert.IsNull(game.Winner);
            Assert.AreEqual(GameScoreEnum.Score0, game.GetGameScore().GetScoreForPlayer(Player.Player1));
        }

        [TestMethod]
        public void SimpleWinPlayer()
        {
            SimpleWinHelper(Player.Player1, Player.Player2);
            SimpleWinHelper(Player.Player2, Player.Player1);
        }

        private void SimpleWinHelper(Player winningPlayer, Player loosingPlayer)
        {
            IGame game = new Game(_gameRulesController, _gameScoreController);

            game.RegisterPoint(winningPlayer);
            Assert.IsNull(game.Winner);
            Assert.AreEqual(GameScoreEnum.Score15, game.GetGameScore().GetScoreForPlayer(winningPlayer));
            Assert.AreEqual(GameScoreEnum.Score0, game.GetGameScore().GetScoreForPlayer(loosingPlayer));

            game.RegisterPoint(winningPlayer);
            Assert.IsNull(game.Winner);
            Assert.AreEqual(GameScoreEnum.Score30, game.GetGameScore().GetScoreForPlayer(winningPlayer));
            Assert.AreEqual(GameScoreEnum.Score0, game.GetGameScore().GetScoreForPlayer(loosingPlayer));

            game.RegisterPoint(winningPlayer);
            Assert.IsNull(game.Winner);
            Assert.AreEqual(GameScoreEnum.Score40, game.GetGameScore().GetScoreForPlayer(winningPlayer));
            Assert.AreEqual(GameScoreEnum.Score0, game.GetGameScore().GetScoreForPlayer(loosingPlayer));

            game.RegisterPoint(winningPlayer);
            Assert.IsNotNull(game.Winner);
            Assert.AreEqual(null, game.GetGameScore().GetScoreForPlayer(winningPlayer));
            Assert.AreEqual(null, game.GetGameScore().GetScoreForPlayer(loosingPlayer));
            Assert.AreEqual(winningPlayer, game.Winner);
        }

        [TestMethod]
        public void GameTiebreak()
        {
            IGame game = new Game(_gameRulesController, _gameScoreController);

            game.RegisterPoint(Player.Player1);
            Assert.IsNull(game.Winner);
            Assert.AreEqual(GameScoreEnum.Score15, game.GetGameScore().GetScoreForPlayer(Player.Player1));
            Assert.AreEqual(GameScoreEnum.Score0, game.GetGameScore().GetScoreForPlayer(Player.Player2));

            game.RegisterPoint(Player.Player2);
            Assert.IsNull(game.Winner);
            Assert.AreEqual(GameScoreEnum.Score15, game.GetGameScore().GetScoreForPlayer(Player.Player1));
            Assert.AreEqual(GameScoreEnum.Score15, game.GetGameScore().GetScoreForPlayer(Player.Player2));

            game.RegisterPoint(Player.Player1);
            Assert.IsNull(game.Winner);
            Assert.AreEqual(GameScoreEnum.Score30, game.GetGameScore().GetScoreForPlayer(Player.Player1));
            Assert.AreEqual(GameScoreEnum.Score15, game.GetGameScore().GetScoreForPlayer(Player.Player2));

            game.RegisterPoint(Player.Player2);
            Assert.IsNull(game.Winner);
            Assert.AreEqual(GameScoreEnum.Score30, game.GetGameScore().GetScoreForPlayer(Player.Player1));
            Assert.AreEqual(GameScoreEnum.Score30, game.GetGameScore().GetScoreForPlayer(Player.Player2));

            game.RegisterPoint(Player.Player1);
            Assert.IsNull(game.Winner);
            Assert.AreEqual(GameScoreEnum.Score40, game.GetGameScore().GetScoreForPlayer(Player.Player1));
            Assert.AreEqual(GameScoreEnum.Score30, game.GetGameScore().GetScoreForPlayer(Player.Player2));

            game.RegisterPoint(Player.Player2);
            Assert.IsNull(game.Winner);
            Assert.AreEqual(GameScoreEnum.Deuce, game.GetGameScore().GetScoreForPlayer(Player.Player1));
            Assert.AreEqual(GameScoreEnum.Deuce, game.GetGameScore().GetScoreForPlayer(Player.Player2));

            game.RegisterPoint(Player.Player1);
            Assert.IsNull(game.Winner);
            Assert.AreEqual(GameScoreEnum.Advantage, game.GetGameScore().GetScoreForPlayer(Player.Player1));
            Assert.AreEqual(null, game.GetGameScore().GetScoreForPlayer(Player.Player2));

            game.RegisterPoint(Player.Player2);
            Assert.IsNull(game.Winner);
            Assert.AreEqual(GameScoreEnum.Deuce, game.GetGameScore().GetScoreForPlayer(Player.Player1));
            Assert.AreEqual(GameScoreEnum.Deuce, game.GetGameScore().GetScoreForPlayer(Player.Player2));

            game.RegisterPoint(Player.Player2);
            Assert.IsNull(game.Winner);
            Assert.AreEqual(null, game.GetGameScore().GetScoreForPlayer(Player.Player1));
            Assert.AreEqual(GameScoreEnum.Advantage, game.GetGameScore().GetScoreForPlayer(Player.Player2));

            game.RegisterPoint(Player.Player2);
            Assert.AreEqual(Player.Player2, game.Winner);
            Assert.AreEqual(null, game.GetGameScore().GetScoreForPlayer(Player.Player1));
            Assert.AreEqual(null, game.GetGameScore().GetScoreForPlayer(Player.Player2));
        }
    }
}