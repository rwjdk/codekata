using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tennis.Logic.Control;
using Tennis.Logic.Interface;

namespace Tennis.Test.Control
{
    [TestClass]
    public class SetRulesControllerTests
    {
        private ISetRulesController _setRulesController;

        [TestInitialize]
        public void Initialize()
        {
            _setRulesController = new SetRulesController();
        }

        [TestMethod]
        public void IsTieBreakScenario()
        {
            Assert.IsTrue(_setRulesController.IsTieBreakScenario(6,6));
            Assert.IsTrue(_setRulesController.IsTieBreakScenario(5,6));
            Assert.IsTrue(_setRulesController.IsTieBreakScenario(6,5));
            Assert.IsTrue(_setRulesController.IsTieBreakScenario(7, 6));
            Assert.IsTrue(_setRulesController.IsTieBreakScenario(6,7));
        }

        [TestMethod]
        public void IsNotTieBreakScenario()
        {
            Assert.IsFalse(_setRulesController.IsTieBreakScenario(0, 0));
            Assert.IsFalse(_setRulesController.IsTieBreakScenario(1, 1));
            Assert.IsFalse(_setRulesController.IsTieBreakScenario(2, 2));
            Assert.IsFalse(_setRulesController.IsTieBreakScenario(3, 3));
            Assert.IsFalse(_setRulesController.IsTieBreakScenario(4, 4));
            Assert.IsFalse(_setRulesController.IsTieBreakScenario(5, 5));
        }

        [TestMethod]
        public void IsWinningScenario()
        {
            Assert.IsTrue(_setRulesController.IsWinningScenario(6, 0));
            Assert.IsTrue(_setRulesController.IsWinningScenario(6, 4));
            Assert.IsTrue(_setRulesController.IsWinningScenario(0, 6));
            Assert.IsTrue(_setRulesController.IsWinningScenario(4, 6));
            Assert.IsTrue(_setRulesController.IsWinningScenario(7, 5));
            Assert.IsTrue(_setRulesController.IsWinningScenario(8, 6));
            Assert.IsTrue(_setRulesController.IsWinningScenario(6, 8));
            Assert.IsTrue(_setRulesController.IsWinningScenario(5, 7));
        }

        [TestMethod]
        public void IsNotWinningScenario()
        {
            Assert.IsFalse(_setRulesController.IsWinningScenario(0, 0));
            Assert.IsFalse(_setRulesController.IsWinningScenario(1, 0));
            Assert.IsFalse(_setRulesController.IsWinningScenario(2, 0));
            Assert.IsFalse(_setRulesController.IsWinningScenario(3, 0));
            Assert.IsFalse(_setRulesController.IsWinningScenario(4, 0));
            Assert.IsFalse(_setRulesController.IsWinningScenario(5, 0));
        }
    }
}