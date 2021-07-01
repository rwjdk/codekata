using Tennis.Logic.Interface;

namespace Tennis
{
    static class Program
    {
        private static IGuiController _guiController;

        static void Main()
        {
            _guiController = DependencyInjection.Resolve<IGuiController>();
            var appController = DependencyInjection.Resolve<IAppController>();
            appController.GameStatusChanged += AppControllerGameResultRegistrated;
            appController.MatchIsOver += AppControllerMatchIsOver;

            while (appController.DoesNotHaveAValidNumberOfSetsInput())
            {
                appController.AskForNumberOfSets();
            }

            appController.StartMatch();

            while (appController.HaveNotYetFoundItsWinner())
            {
                appController.AskForResultOfNextGame();
            }
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
