using Autofac;
using Tennis.Control;
using Tennis.Logic;
using Tennis.Logic.Control;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace Tennis
{
    internal static class DependencyInjection
    {
        private static IContainer _container;

        private static IContainer BuildContainer()
        {
            if (_container != null)
            {
                return _container;
            }

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<NumberOfSetsController>().As<INumberOfSetsController>();
            containerBuilder.RegisterType<MatchRulesController>().As<IMatchRulesController>();
            containerBuilder.RegisterType<SetRulesController>().As<ISetRulesController>();
            containerBuilder.RegisterType<GameScoreController>().As<IGameScoreController>();
            containerBuilder.RegisterType<GameRulesController>().As<IGameRulesController>();
            containerBuilder.RegisterType<AppController>().As<IAppController>();
            containerBuilder.RegisterType<ConsoleGuiController>().As<IGuiController>();
            containerBuilder.RegisterType<AutomationController>().As<IAutomationController>();
            containerBuilder.RegisterType<MatchController>().As<IMatchController>();
            containerBuilder.RegisterType<ConsoleTerminationController>().As<ITerminationController>();
            containerBuilder.RegisterType<GameScoreFormatter>().As<IGameScoreFormatter>();
            _container = containerBuilder.Build();
            return _container;
        }

        internal static T Resolve<T>()
        {
            return BuildContainer().Resolve<T>();
        }
    }
}