using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberToLcd.Gui.Control;
using NumberToLcd.Gui.Interface;
using NumberToLcd.Test.Helpers;

namespace NumberToLcd.Test.Gui.Control
{
    [TestClass]
    public class InteractiveLoopTest
    {
        private IContainer _container;

        [TestInitialize]
        public void Initialize()
        {
            _container = IocTestContainerBuilder.BuildContainer();
        }

        [TestMethod]
        public void Foo()
        {
            //TODO - How the hell do you use dependency injection (pretty) here?!?

            var fakeConsoleController = new FakeConsoleController(
                "1234567890",
                "abc",
                "2x 2y 1234567890c",
                "EXIT"
                );

            var numberWriter = new NumberWriter(fakeConsoleController);
            var loopTerminator = _container.Resolve<IInteractivLoopTerminator>();
            var inputToNumberController = _container.Resolve<IInputToNumberController>();
            var interactiveLoop = new InteractiveLoop(inputToNumberController, numberWriter, fakeConsoleController, loopTerminator);
            interactiveLoop.InitiateUserInteraction();

            Assert.IsTrue(fakeConsoleController.FullMessageGivenToConsole.Length > 0);
        }
    }
}