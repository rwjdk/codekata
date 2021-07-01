using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tennis.Logic.Control;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace Tennis.Test.Model
{
    [TestClass]
    public class SetTests
    {
        private ISetRulesController _setRulesController;

        [TestInitialize]
        public void Initialize()
        {
            _setRulesController = DependencyInjection.Resolve<ISetRulesController>();
        }

        [TestMethod]
        public void RegisterSets()
        {
            ISet set = new Set(_setRulesController, 1);
            Assert.AreEqual(1, set.SetNumber);
            set.RegisterGame(Player.Player1);
            Assert.AreEqual(1, set.GetWonGamesForPlayer(Player.Player1));
            Assert.AreEqual(0, set.GetWonGamesForPlayer(Player.Player2));
            set.RegisterGame(Player.Player2);
            Assert.AreEqual(1, set.GetWonGamesForPlayer(Player.Player1));
            Assert.AreEqual(1, set.GetWonGamesForPlayer(Player.Player2));
            set.RegisterGame(Player.Player2);
            Assert.AreEqual(1, set.GetWonGamesForPlayer(Player.Player1));
            Assert.AreEqual(2, set.GetWonGamesForPlayer(Player.Player2));
        }
    }
}