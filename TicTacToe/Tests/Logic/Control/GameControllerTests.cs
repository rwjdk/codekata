using System;
using Logic.Controller;
using Logic.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Fakes;

namespace Tests.Logic.Control
{
    [TestClass]
    public class GameControllerTests
    {
        [TestMethod]
        public void HostGame()
        {
            var gameController = GetController(new FakeGameStateController());

            var gameId = gameController.HostGame();
            Assert.AreEqual(true, gameController.IsItMyTurn());
            Assert.AreEqual(Player.HostingPlayer, gameController.Game.StartingPlayer);
            Assert.AreEqual(Player.HostingPlayer, gameController.Me.Player);
            Assert.AreEqual("X", gameController.Me.Symbol);
            Assert.AreEqual(Player.JoiningPlayer, gameController.Opponent.Player);
            Assert.AreEqual("O", gameController.Opponent.Symbol);

            Assert.AreEqual(1234, gameId);
        }

        [TestMethod]
        public void HostGameWhereHostingPlayerIsNotFirstPlayer()
        {
            var gameController = GetController(new FakeGameStateController(), Player.JoiningPlayer);

            var gameId = gameController.HostGame();
            Assert.AreEqual(false, gameController.IsItMyTurn());
            Assert.AreEqual(Player.JoiningPlayer, gameController.Game.StartingPlayer);
            Assert.AreEqual(Player.HostingPlayer, gameController.Me.Player);
            Assert.AreEqual("O", gameController.Me.Symbol);
            Assert.AreEqual(Player.JoiningPlayer, gameController.Opponent.Player);
            Assert.AreEqual("X", gameController.Opponent.Symbol);

            Assert.AreEqual(1234, gameId);
        }

        [TestMethod]
        public void JoinGame()
        {
            var gameController = GetController(new FakeGameStateController());
            gameController.JoinGame(1234);
            Assert.AreEqual(false, gameController.IsItMyTurn());
            Assert.AreEqual(1234, gameController.Game.Id);
            Assert.AreEqual(Player.HostingPlayer, gameController.Game.StartingPlayer);
            Assert.AreEqual(Player.JoiningPlayer, gameController.Me.Player);
            Assert.AreEqual("O", gameController.Me.Symbol);
            Assert.AreEqual(Player.HostingPlayer, gameController.Opponent.Player);
            Assert.AreEqual("X", gameController.Opponent.Symbol);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void JoinGameThatDoesNotExist()
        {
            var gameController = GetController(new FakeGameStateController());
            gameController.JoinGame(0);

        }

        [TestMethod]
        public void PlayAGameWhereHostingPlayerWin()
        {
            var sharedGameStateController = new FakeGameStateController();
            var gameControllerHost = GetController(sharedGameStateController);
            var gameControllerJoin = GetController(sharedGameStateController);

            var gameId = gameControllerHost.HostGame();
            
            gameControllerHost.MakeMove(0, 0);

            gameControllerJoin.JoinGame(gameId);

            gameControllerJoin.MakeMove(0,1);
            gameControllerHost.MakeMove(1,1);
            gameControllerJoin.MakeMove(0,2);
            gameControllerHost.MakeMove(2,2);
            gameControllerJoin.MakeMove(2,0);
            

            Assert.AreEqual(Player.HostingPlayer, gameControllerHost.Game.GetWinner());
            Assert.AreEqual(Player.HostingPlayer, gameControllerJoin.Game.GetWinner());
        }

        [TestMethod]
        public void PlayAGameWhereJoiningPlayerWin()
        {
            var sharedGameStateController = new FakeGameStateController();
            var gameControllerHost = GetController(sharedGameStateController);
            var gameControllerJoin = GetController(sharedGameStateController);

            var gameId = gameControllerHost.HostGame();

            gameControllerHost.MakeMove(0, 2);

            gameControllerJoin.JoinGame(gameId);
            
            gameControllerJoin.MakeMove(0, 0);
            gameControllerHost.MakeMove(0, 1);
            gameControllerJoin.MakeMove(1, 0);
            gameControllerHost.MakeMove(2, 2);
            gameControllerJoin.MakeMove(2, 0);
            
            Assert.AreEqual(Player.JoiningPlayer, gameControllerHost.Game.GetWinner());
            Assert.AreEqual(Player.JoiningPlayer, gameControllerJoin.Game.GetWinner());
        }

        [TestMethod]
        public void PlayAGameThatEndInATie()
        {
            var sharedGameStateController = new FakeGameStateController();
            var gameControllerHost = GetController(sharedGameStateController);
            var gameControllerJoin = GetController(sharedGameStateController);

            var gameId = gameControllerHost.HostGame();
            gameControllerHost.MakeMove(0, 0);

            gameControllerJoin.JoinGame(gameId);
            
            gameControllerJoin.MakeMove(0, 1);
            gameControllerHost.MakeMove(1, 1);
            gameControllerJoin.MakeMove(0, 2);
            gameControllerHost.MakeMove(1, 2);
            gameControllerJoin.MakeMove(1, 0);
            gameControllerHost.MakeMove(2, 0);
            gameControllerJoin.MakeMove(2, 2);
            gameControllerHost.MakeMove(2, 1);
            
            Assert.AreEqual(true, gameControllerHost.Game.NoMoreMovesLeft());
            Assert.AreEqual(true, gameControllerJoin.Game.NoMoreMovesLeft());
            Assert.AreEqual(Player.None, gameControllerHost.Game.GetWinner());
            Assert.AreEqual(Player.None, gameControllerJoin.Game.GetWinner());
        }
        
        private static GameController GetController(FakeGameStateController fakeGameStateController, Player startingPlayer = Player.HostingPlayer)
        {
            var gameIdController = new FakeGameIdController();
            var startingPlayerController = new FakeStartingPlayerController(startingPlayer);
            var waitForOpponentController = new FakeWaitForOpponentController();
            var gameController = new GameController(gameIdController, startingPlayerController, fakeGameStateController, waitForOpponentController);
            return gameController;
        }
    }
}