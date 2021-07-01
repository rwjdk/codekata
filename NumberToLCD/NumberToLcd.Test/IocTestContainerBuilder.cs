using System.Diagnostics.CodeAnalysis;
using Autofac;
using NumberToLcd.Gui.Control;
using NumberToLcd.Gui.Interface;
using NumberToLcd.Test.Helpers;

namespace NumberToLcd.Test
{
    [ExcludeFromCodeCoverage]
    public static class IocTestContainerBuilder
    {
        public static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<InteractiveLoop>().As<IInteractiveLoop>();
            containerBuilder.RegisterType<NumberWriter>().As<INumberWriter>();
            containerBuilder.RegisterType<InputToNumberController>().As<IInputToNumberController>();
            containerBuilder.RegisterType<FakeConsoleController>().As<IConsoleController>().SingleInstance();
            containerBuilder.RegisterType<FakeInteractiveLoopTerminator>().As<IInteractivLoopTerminator>();
            return containerBuilder.Build();
        }
    }
}