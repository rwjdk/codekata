using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tennis.Logic.Control;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;
using Tennis.Test.Fakes;

namespace Tennis.Test.Control
{
    [TestClass]
    public class AppControllerTests
    {
        [TestMethod]
        public void TestInvalidInputDuringAskForNumberOfSets()
        {
            var appController = GetTestController(NumberOfSetsUserInput.InvalidInput, 0);
            appController.AskForNumberOfSets();
        }

        [TestMethod]
        public void TestExitInputDuringAskForNumberOfSets()
        {
            var appController = GetTestController(NumberOfSetsUserInput.Exit, 0);
            appController.AskForNumberOfSets();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIncorrectInputDuringAskForNumberOfSets()
        {
            var appController = GetTestController((NumberOfSetsUserInput)9999, 0);
            appController.AskForNumberOfSets();
        }
        
        [TestMethod]
        public void Normal5SetGamePlayed()
        {
            var automationController = DependencyInjection.Resolve<IAutomationController>();
            var appController = GetTestController(NumberOfSetsUserInput.ValidInput, 5);
            appController.MatchIsOver += obj =>
            {
                Assert.AreEqual(5, obj.Sets.Count);
                Assert.AreEqual(true, obj.Winner.HasValue);
            };

            while (appController.IsNumberOfSetsNotDefined())
            {
                appController.AskForNumberOfSets();
            }

            appController.StartMatch();

            while (appController.HaveNotYetFoundItsWinner())
            {
                var gameWinner = automationController.GetRandomPlayer();
                appController.SetWinnerOfNextGame(gameWinner);
            }
        }
        
        [TestMethod]
        public void Normal3SetGamePlayed()
        {
            var automationController = DependencyInjection.Resolve<IAutomationController>();
            var appController = GetTestController(NumberOfSetsUserInput.ValidInput, 3);
            appController.MatchIsOver += obj =>
            {
                Assert.AreEqual(3, obj.Sets.Count);
                Assert.AreEqual(true, obj.Winner.HasValue);
            };

            while (appController.IsNumberOfSetsNotDefined())
            {
                appController.AskForNumberOfSets();
            }

            appController.StartMatch();

            while (appController.HaveNotYetFoundItsWinner())
            {
                var gameWinner = automationController.GetRandomPlayer();
                appController.SetWinnerOfNextGame(gameWinner);
            }
        }
        
        [TestMethod]
        public void Normal1SetGamePlayed()
        {
            var automationController = DependencyInjection.Resolve<IAutomationController>();
            var appController = GetTestController(NumberOfSetsUserInput.ValidInput, 1);
            appController.MatchIsOver += obj =>
            {
                Assert.AreEqual(1, obj.Sets.Count);
                Assert.AreEqual(true, obj.Winner.HasValue);
            };

            while (appController.IsNumberOfSetsNotDefined())
            {
                appController.AskForNumberOfSets();
            }

            appController.StartMatch();

            while (appController.HaveNotYetFoundItsWinner())
            {
                var gameWinner = automationController.GetRandomPlayer();
                appController.SetWinnerOfNextGame(gameWinner);
            }
        }

        private static AppController GetTestController(NumberOfSetsUserInput numberOfSetsUserInput, int numberOfSets)
        {
            var numberOfSetsController = new NumberOfSetsController();
            var matchRulesController = new MatchRulesController();
            var gameRulesController = new GameRulesController();
            var gameScoreController = new GameScoreController(gameRulesController);
            var setRulesController = new SetRulesController();
            var matchController = new MatchController(gameScoreController, setRulesController, matchRulesController);
            var testTerminationController = new TestTerminationController();
            var testGuiController = new TestGuiController(numberOfSetsUserInput, numberOfSets);
            var appController = new AppController(numberOfSetsController, matchController, testGuiController, testTerminationController);
            return appController;
        }
    }
}