using System.Diagnostics.CodeAnalysis;
using Autofac;
using NumberToLcd.Gui.Control;
using NumberToLcd.Gui.Interface;

namespace NumberToLcd.Gui
{
    [ExcludeFromCodeCoverage]
    public static class IocContainerBuilder
    {
        public static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<InteractiveLoop>().As<IInteractiveLoop>();
            containerBuilder.RegisterType<NumberWriter>().As<INumberWriter>();
            containerBuilder.RegisterType<InputToNumberController>().As<IInputToNumberController>();
            containerBuilder.RegisterType<ConsoleController>().As<IConsoleController>().SingleInstance();
            containerBuilder.RegisterType<InteractiveLoopTerminator>().As<IInteractivLoopTerminator>();
            return containerBuilder.Build();
        }
    }
}