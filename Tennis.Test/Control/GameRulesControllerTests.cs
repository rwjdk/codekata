using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tennis.Logic.Control;
using Tennis.Logic.Interface;

namespace Tennis.Test.Control
{
    [TestClass]
    public class GameRulesControllerTests
    {
        private IGameRulesController _gameRulesController;

        [TestInitialize]
        public void Initialize()
        {
            _gameRulesController = DependencyInjection.Resolve<IGameRulesController>();
        }

        [TestMethod]
        public void IsNotTieBreak()
        {
            Assert.IsFalse(_gameRulesController.IsTieBreakScenario(0, 0));
            Assert.IsFalse(_gameRulesController.IsTieBreakScenario(1, 1));
            Assert.IsFalse(_gameRulesController.IsTieBreakScenario(2, 2));
        }

        [TestMethod]
        public void IsTieBreak()
        {
            Assert.IsTrue(_gameRulesController.IsTieBreakScenario(3, 3));
        }

        [TestMethod]
        public void IsNotWinningScenario()
        {
            Assert.IsFalse(_gameRulesController.IsWinningScenario(0, 0));
            Assert.IsFalse(_gameRulesController.IsWinningScenario(1, 0));
            Assert.IsFalse(_gameRulesController.IsWinningScenario(2, 0));
            Assert.IsFalse(_gameRulesController.IsWinningScenario(3, 0));
            Assert.IsFalse(_gameRulesController.IsWinningScenario(3, 3));
            Assert.IsFalse(_gameRulesController.IsWinningScenario(4, 3));
        }

        [TestMethod]
        public void IsWinningScenario()
        {
            Assert.IsTrue(_gameRulesController.IsWinningScenario(4, 0));
            Assert.IsTrue(_gameRulesController.IsWinningScenario(5, 3));
            Assert.IsTrue(_gameRulesController.IsWinningScenario(0, 4));
            Assert.IsTrue(_gameRulesController.IsWinningScenario(3, 5));
        }
    }
}