using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace Tennis.Test.Model
{
    [TestClass]
    public class MatchTests
    {
        private IMatchController _matchController;

        [TestInitialize]
        public void Initialize()
        {
            _matchController = DependencyInjection.Resolve<IMatchController>();
        }

        [TestMethod]
        public void NewMatchIsEmpty()
        {
            IMatch match = _matchController.CreateMatch(3);
            Assert.AreEqual(null, match.Winner);
            Assert.AreEqual(null, match.CurrentGame.Winner);
            Assert.AreEqual(new GameScore(GameScoreEnum.Score0, GameScoreEnum.Score0), match.CurrentGame.GetGameScore());
            Assert.AreEqual(Player.Player1, match.CurrentServe);
            Assert.AreEqual(1, match.CurrentSetNumber);
            Assert.AreEqual(3, match.Sets.Count);
            foreach (var set in match.Sets)
            {
                Assert.AreEqual(null, set.Winner);
                Assert.AreEqual(0, set.GetWonGamesForPlayer(Player.Player1));
                Assert.AreEqual(0, set.GetWonGamesForPlayer(Player.Player2));
            }
        }

        [TestMethod]
        public void NewMatchAfter1PointToPlayer1()
        {
            IMatch match = _matchController.CreateMatch(3);
            match.RegisterPoint(Player.Player1);
            Assert.AreEqual(null, match.Winner);
            Assert.AreEqual(new GameScore(GameScoreEnum.Score15, GameScoreEnum.Score0), match.CurrentGame.GetGameScore());
        }

        [TestMethod]
        public void NewMatchAfter1GamePointToPlayer1()
        {
            IMatch match = _matchController.CreateMatch(3);
            var points = 4;
            for (int i = 0; i < points; i++)
            {
                match.RegisterPoint(Player.Player1);
            }
            Assert.AreEqual(null, match.Winner);
            Assert.AreEqual(null, match.CurrentGame.Winner); //Reset
            Assert.AreEqual(1, match.CurrentSet.GetWonGamesForPlayer(Player.Player1));
        }

        [TestMethod]
        public void NewMatchAfter1SetAnd1GamePointToPlayer1()
        {
            IMatch match = _matchController.CreateMatch(3);
            var points = 4;
            var games = 7;
            for (int i = 0; i < points * games; i++)
            {
                match.RegisterPoint(Player.Player1);
            }
            Assert.AreEqual(null, match.Winner);
            Assert.AreEqual(null, match.CurrentGame.Winner); //Reset
            Assert.AreEqual(2, match.CurrentSetNumber);
            var firstSet = match.Sets[0];
            Assert.AreEqual(6, firstSet.GetWonGamesForPlayer(Player.Player1));
            Assert.AreEqual(1, match.CurrentSet.GetWonGamesForPlayer(Player.Player1));
        }

        [TestMethod]
        public void NewMatchAfterAllPointsToPlayer1()
        {
            IMatch match = _matchController.CreateMatch(3);
            var points = 4;
            var games = 6;
            var sets = 2;
            for (int i = 0; i < points * games * sets; i++)
            {
                match.RegisterPoint(Player.Player1);
            }
            Assert.AreEqual(Player.Player1, match.Winner);
            var firstSet = match.Sets[0];
            Assert.AreEqual(6, firstSet.GetWonGamesForPlayer(Player.Player1));
            var secondSet = match.Sets[1];
            Assert.AreEqual(6, secondSet.GetWonGamesForPlayer(Player.Player1));
        }
    }
}