using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberToLcd.Gui.Interface;
using NumberToLcd.Logic.Model;
using NumberToLcd.Test.Helpers;

namespace NumberToLcd.Test.Gui.Control
{
    [TestClass]
    public class NumberWriterTest
    {
        private IContainer _container;

        [TestInitialize]
        public void Initialize()
        {
            _container = IocTestContainerBuilder.BuildContainer();
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [ExcludeFromCodeCoverage]
        public void NullNumbers()
        {
            var writer = _container.Resolve<INumberWriter>();
            writer.WriteNumbers(null);
        }

        [TestMethod]
        public void NoNumbers()
        {
            var writer = _container.Resolve<INumberWriter>();
            writer.WriteNumbers(new List<Number>());

            var fakeConsoleController = (FakeConsoleController)writer.Console;
            Assert.AreEqual("", fakeConsoleController.FullMessageGivenToConsole.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [ExcludeFromCodeCoverage]
        public void InvalidWidthFactor()
        {
            var writer = _container.Resolve<INumberWriter>();
            writer.WriteNumbers(new List<Number>(), widthFactor: -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [ExcludeFromCodeCoverage]
        public void InvalidHeightFactor()
        {
            var writer = _container.Resolve<INumberWriter>();
            writer.WriteNumbers(new List<Number>(), heightFactor: -1);
        }

        [TestMethod]
        public void WriteNormal()
        {
                var writer = _container.Resolve<INumberWriter>();
                var numbers = new List<Number>
                {
                    new Number(1),
                    new Number(2),
                    new Number(3),
                    new Number(4),
                    new Number(5),
                    new Number(6),
                    new Number(7),
                    new Number(8),
                    new Number(9),
                    new Number(0)
                };
                writer.WriteNumbers(numbers);

                string result =
                    "    _  _     _  _  _  _  _  _ " +
                    "  | _| _||_||_ |_   ||_||_|| |" +
                    "  ||_  _|  | _||_|  ||_| _||_|";
                var fakeConsoleController = (FakeConsoleController)writer.Console;
                Assert.AreEqual(result, fakeConsoleController.FullMessageGivenToConsole.ToString());
                Assert.IsFalse(fakeConsoleController.ColorSet);
        }

        [TestMethod]
        public void Write2X()
        {
            var writer = _container.Resolve<INumberWriter>();
            var numbers = new List<Number>
            {
                new Number(1),
                new Number(2),
                new Number(3),
                new Number(4),
                new Number(5),
                new Number(6),
                new Number(7),
                new Number(8),
                new Number(9),
                new Number(0)
            };
            writer.WriteNumbers(numbers, 2, 2, true);

            string result =
                "     __  __      __  __  __  __  __  __ " +
                "   |   |   ||  ||   |      ||  ||  ||  |" +
                "   | __| __||__||__ |__    ||__||__||  |" +
                "   ||      |   |   ||  |   ||  |   ||  |" +
                "   ||__  __|   | __||__|   ||__| __||__|";

            var fakeConsoleController = (FakeConsoleController)writer.Console;
            Assert.AreEqual(result, fakeConsoleController.FullMessageGivenToConsole.ToString());
            Assert.IsTrue(fakeConsoleController.ColorSet);
        }
    }
}