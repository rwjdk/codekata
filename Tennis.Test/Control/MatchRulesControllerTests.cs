using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tennis.Logic.Control;
using Tennis.Logic.Interface;

namespace Tennis.Test.Control
{
    [TestClass]
    public class MatchRulesControllerTests
    {
        private IMatchRulesController _matchRulesController;

        [TestInitialize]
        public void Initialize()
        {
            _matchRulesController = DependencyInjection.Resolve<IMatchRulesController>();
        }

        [TestMethod]
        public void IsWinningScenario()
        {
            Assert.IsTrue(_matchRulesController.IsWinningScenario(numberOfSets: 1, player1Sets: 1, player2Sets: 0));
            Assert.IsTrue(_matchRulesController.IsWinningScenario(numberOfSets: 1, player1Sets: 0, player2Sets: 1));

            Assert.IsTrue(_matchRulesController.IsWinningScenario(numberOfSets: 3, player1Sets: 2, player2Sets: 0));
            Assert.IsTrue(_matchRulesController.IsWinningScenario(numberOfSets: 3, player1Sets: 0, player2Sets: 2));

            Assert.IsTrue(_matchRulesController.IsWinningScenario(numberOfSets: 5, player1Sets: 3,player2Sets: 0));
            Assert.IsTrue(_matchRulesController.IsWinningScenario(numberOfSets: 5, player1Sets: 0,player2Sets: 3));
        }
    }
}