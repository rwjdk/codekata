using Autofac;
using Tennis.Logic.Control;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;
using Tennis.Test.Fakes;

namespace Tennis.Test
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
            containerBuilder.RegisterType<AutomationController>().As<IAutomationController>();
            containerBuilder.RegisterType<MatchController>().As<IMatchController>();
            containerBuilder.RegisterType<TestGuiController>().As<IGuiController>();
            containerBuilder.RegisterType<TestTerminationController>().As<ITerminationController>();
            containerBuilder.RegisterType<AppController>().As<IAppController>();
            containerBuilder.RegisterType<GameScoreFormatter>().As<IGameScoreFormatter>();
            containerBuilder.RegisterType<Game>().As<IGame>();
            _container = containerBuilder.Build();
            return _container;
        }

        internal static T Resolve<T>()
        {
            return BuildContainer().Resolve<T>();
        }
    }
}