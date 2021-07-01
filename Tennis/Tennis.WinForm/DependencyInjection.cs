using Autofac;
using Tennis.Logic;
using Tennis.Logic.Control;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;
using Tennis.WinForm.Control;

namespace Tennis.WinForm
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
            containerBuilder.RegisterType<WinFormGuiController>().As<IGuiController>();
            containerBuilder.RegisterType<WinFormTerminationController>().As<ITerminationController>();
            containerBuilder.RegisterType<AutomationController>().As<IAutomationController>();
            containerBuilder.RegisterType<MatchController>().As<IMatchController>();
            containerBuilder.RegisterType<GameScoreFormatter>().As<IGameScoreFormatter>();
            _container = containerBuilder.Build();
            return _container;
        }

        internal static T Resolve<T>()
        {
            return BuildContainer().Resolve<T>();
        }
    }}