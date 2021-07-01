using System.Linq;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberToLcd.Gui.Interface;

namespace NumberToLcd.Test.Gui.Control
{
    [TestClass]
    public class InputToNumberControllerTest
    {
        private IContainer _container;

        [TestInitialize]
        public void Initialize()
        {
            _container = IocTestContainerBuilder.BuildContainer();
        }

        [TestMethod]
        public void NormalInput()
        {
            var controller = _container.Resolve<IInputToNumberController>();
            var result = controller.Parse("1234567890");
            Assert.AreEqual(10, result.Numbers.Count);
            Assert.AreEqual("1234567890", string.Join("", result.Numbers.Select(x => x.Value)));
            Assert.AreEqual(1, result.WidthFactor);
            Assert.AreEqual(1, result.HeightFactor);
            Assert.AreEqual(false, result.UseColors);
        }

        [TestMethod]
        public void InputWithFactorsAndColors()
        {
            var controller = _container.Resolve<IInputToNumberController>();
            var result = controller.Parse("2x 3y 1234567890c");
            Assert.AreEqual(10, result.Numbers.Count);
            Assert.AreEqual("1234567890", string.Join("", result.Numbers.Select(x => x.Value)));
            Assert.AreEqual(2, result.WidthFactor);
            Assert.AreEqual(3, result.HeightFactor);
            Assert.AreEqual(true, result.UseColors);
        }

        [TestMethod]
        public void InvalidInputProduceNull()
        {
            var controller = _container.Resolve<IInputToNumberController>();
            var result = controller.Parse("abcd");
            Assert.AreEqual(null, result);
        }
    }
}