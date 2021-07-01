using System;
using System.Threading;
using Tennis.Logic.Control;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace Tennis.View
{
    class Program
    {

        static void Main()
        {
            //Todo - make tie break set more correct (whole other game-mode)

            /* Things for discussion
             * - Interfaces (Now???, Needed???, Share???)
             * - Test-coverage
             * - S.O.L.I.D
             */

            var gameRulesController = new GameRulesController();
            var setController = new SetRulesController();
            var matchRulesController = new MatchRulesController();

            var gameScoreController = new GameScoreController(gameRulesController);

            var outputController = new OutputViewController();

            var numberOfSets = 0;
            while (numberOfSets == 0)
            {
                outputController.PrintNumberOfSetSelection();
                var userInput = Console.ReadLine()?.ToUpperInvariant();
                switch (userInput)
                {
                    case "1":
                        numberOfSets = 1;
                        break;
                    case "3":
                        numberOfSets = 3;
                        break;
                    case "5":
                        numberOfSets = 5;
                        break;
                    case "EXIT":
                        Environment.Exit(-1);
                        break;
                    default:
                        outputController.PrintInvalidInputMessage();
                        continue;
                }
            }


            IMatch match = new Match(numberOfSets, gameRulesController, gameScoreController, setController, matchRulesController);

            outputController.PrintMatchStatus(match);

            while (!match.Winner.HasValue)
            {
                switch (_gameMode)
                {
                    case GameMode.UserInput:
                        outputController.PrintInstructions();
                        var userInput = Console.ReadLine()?.ToUpperInvariant();
                        switch (userInput)
                        {
                            case "1":
                            case "2":
                                match.RegisterPoint((Player)Convert.ToInt32(userInput));
                                break;
                            case "EXIT":
                                Environment.Exit(-1);
                                break;
                            case "AUTO":
                                _gameMode = GameMode.Auto;
                                break;
                            default:
                                outputController.PrintInvalidInputMessage();
                                continue;
                        }
                        break;
                    case GameMode.Auto:
                        var randomPlayer = _automation.GetRandomPlayer();
                        match.RegisterPoint(randomPlayer);
                        Thread.Sleep(10);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                outputController.PrintMatchStatus(match);
            }
            outputController.PrintFinalResult(match);
        }

        #region Automation
        private static Automation _automation = new Automation();
        private static GameMode _gameMode = GameMode.UserInput;

        internal enum GameMode
        {
            UserInput,
            Auto,
        }

        private class Automation
        {
            private Random _random;

            public Automation()
            {
                _random = new Random(DateTime.Now.Millisecond);
            }

            public Player GetRandomPlayer()
            {
                var next = _random.Next(1, 3);
                return (Player)next;
            }
        }
        #endregion
    }
}
