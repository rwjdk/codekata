using System.Diagnostics.CodeAnalysis;
using Autofac;
using NumberToLcd.Gui.Interface;

namespace NumberToLcd.Gui
{
    [ExcludeFromCodeCoverage]
    static class Program
    {
        static void Main()
        {
            using (var container = IocContainerBuilder.BuildContainer())
            {
                container.Resolve<IInteractiveLoop>().InitiateUserInteraction();
            }
        }
    }
}
