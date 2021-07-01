using System;
using Tennis.Logic.Interface;

namespace Tennis.View
{
    static class Program
    {
        private static IGuiController _guiController;

        static void Main()
        {
            _guiController = DependencyInjection.Resolve<IGuiController>();
            _guiController.ExitRequested += GuiControllerExitRequested;
            var appController = DependencyInjection.Resolve<IAppController>();
            appController.GameStatusChanged += AppControllerGameResultRegistrated;
            appController.MatchIsOver += AppControllerMatchIsOver;

            while (appController.IsNumberOfSetsNotDefined())
            {
                appController.AskForNumberOfSets();
            }

            appController.StartMatch();

            while (appController.HaveNotYetFoundItsWinner())
            {
                var gameWinner = _guiController.AskForWinnerOfNextGame();
                if (gameWinner.HasValue)
                {
                    appController.SetWinnerOfNextGame(gameWinner.Value);
                }
            }
        }

        private static void GuiControllerExitRequested()
        {
            Environment.Exit(-1);
        }

        private static void AppControllerMatchIsOver(IMatch obj)
        {
            _guiController.DisplayFinalResult(obj);
        }

        private static void AppControllerGameResultRegistrated(IMatch obj)
        {
            _guiController.PrintMatchStatus(obj);
        }
    }
}
