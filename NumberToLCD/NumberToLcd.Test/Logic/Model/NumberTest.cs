using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberToLcd.Logic.Model;

namespace NumberToLcd.Test.Logic.Model
{
    [TestClass]
    public class NumberTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [ExcludeFromCodeCoverage]
        public void InvalidValueToLow()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Number(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [ExcludeFromCodeCoverage]
        public void InvalidValueToHigh()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Number(10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [ExcludeFromCodeCoverage]
        public void InvalidSection()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Number(5).GetNumberSection((NumberSection)999);
        }

        [TestMethod]
        public void Value0()
        {
            // ReSharper disable once ObjectCreationAsStatement
            var number = new Number(0);
            Assert.AreEqual(0, number.Value);
            Assert.AreEqual(" _ ", number.GetNumberSection(NumberSection.Top));
            Assert.AreEqual("| |", number.GetNumberSection(NumberSection.Middle));
            Assert.AreEqual("|_|", number.GetNumberSection(NumberSection.Bottom));
        }

        [TestMethod]
        public void Value0X2()
        {
            // ReSharper disable once ObjectCreationAsStatement
            var number = new Number(0);
            Assert.AreEqual(0, number.Value);
            Assert.AreEqual(" __ ", number.GetNumberSection(NumberSection.Top, 2));
            Assert.AreEqual("|  |", number.GetNumberSection(NumberSection.ScaledMiddleUpper, 2));
            Assert.AreEqual("|  |", number.GetNumberSection(NumberSection.Middle, 2));
            Assert.AreEqual("|  |", number.GetNumberSection(NumberSection.ScaledMiddleLower, 2));
            Assert.AreEqual("|__|", number.GetNumberSection(NumberSection.Bottom, 2));
        }

        [TestMethod]
        public void Value1()
        {
            // ReSharper disable once ObjectCreationAsStatement
            var number = new Number(1);
            Assert.AreEqual(1, number.Value);
            Assert.AreEqual("   ", number.GetNumberSection(NumberSection.Top));
            Assert.AreEqual("  |", number.GetNumberSection(NumberSection.Middle));
            Assert.AreEqual("  |", number.GetNumberSection(NumberSection.Bottom));
        }

        [TestMethod]
        public void Value1X2()
        {
            // ReSharper disable once ObjectCreationAsStatement
            var number = new Number(1);
            Assert.AreEqual(1, number.Value);
            Assert.AreEqual("    ", number.GetNumberSection(NumberSection.Top, 2));
            Assert.AreEqual("   |", number.GetNumberSection(NumberSection.ScaledMiddleUpper, 2));
            Assert.AreEqual("   |", number.GetNumberSection(NumberSection.Middle, 2));
            Assert.AreEqual("   |", number.GetNumberSection(NumberSection.ScaledMiddleLower, 2));
            Assert.AreEqual("   |", number.GetNumberSection(NumberSection.Bottom, 2));
        }

        [TestMethod]
        public void Value2()
        {
            // ReSharper disable once ObjectCreationAsStatement
            var number = new Number(2);
            Assert.AreEqual(2, number.Value);
            Assert.AreEqual(" _ ", number.GetNumberSection(NumberSection.Top));
            Assert.AreEqual(" _|", number.GetNumberSection(NumberSection.Middle));
            Assert.AreEqual("|_ ", number.GetNumberSection(NumberSection.Bottom));
        }

        [TestMethod]
        public void Value2X2()
        {
            // ReSharper disable once ObjectCreationAsStatement
            var number = new Number(2);
            Assert.AreEqual(2, number.Value);
            Assert.AreEqual(" __ ", number.GetNumberSection(NumberSection.Top, 2));
            Assert.AreEqual("   |", number.GetNumberSection(NumberSection.ScaledMiddleUpper, 2));
            Assert.AreEqual(" __|", number.GetNumberSection(NumberSection.Middle, 2));
            Assert.AreEqual("|   ", number.GetNumberSection(NumberSection.ScaledMiddleLower, 2));
            Assert.AreEqual("|__ ", number.GetNumberSection(NumberSection.Bottom, 2));
        }

        [TestMethod]
        public void Value3()
        {
            // ReSharper disable once ObjectCreationAsStatement
            var number = new Number(3);
            Assert.AreEqual(3, number.Value);
            Assert.AreEqual(" _ ", number.GetNumberSection(NumberSection.Top));
            Assert.AreEqual(" _|", number.GetNumberSection(NumberSection.Middle));
            Assert.AreEqual(" _|", number.GetNumberSection(NumberSection.Bottom));
        }

        [TestMethod]
        public void Value3X2()
        {
            // ReSharper disable once ObjectCreationAsStatement
            var number = new Number(3);
            Assert.AreEqual(3, number.Value);
            Assert.AreEqual(" __ ", number.GetNumberSection(NumberSection.Top, 2));
            Assert.AreEqual("   |", number.GetNumberSection(NumberSection.ScaledMiddleUpper, 2));
            Assert.AreEqual(" __|", number.GetNumberSection(NumberSection.Middle, 2));
            Assert.AreEqual("   |", number.GetNumberSection(NumberSection.ScaledMiddleLower, 2));
            Assert.AreEqual(" __|", number.GetNumberSection(NumberSection.Bottom, 2));
        }

        [TestMethod]
        public void Value4()
        {
            // ReSharper disable once ObjectCreationAsStatement
            var number = new Number(4);
            Assert.AreEqual(4, number.Value);
            Assert.AreEqual("   ", number.GetNumberSection(NumberSection.Top));
            Assert.AreEqual("|_|", number.GetNumberSection(NumberSection.Middle));
            Assert.AreEqual("  |", number.GetNumberSection(NumberSection.Bottom));
        }

        [TestMethod]
        public void Value4X2()
        {
            // ReSharper disable once ObjectCreationAsStatement
            var number = new Number(4);
            Assert.AreEqual(4, number.Value);
            Assert.AreEqual("    ", number.GetNumberSection(NumberSection.Top, 2));
            Assert.AreEqual("|  |", number.GetNumberSection(NumberSection.ScaledMiddleUpper, 2));
            Assert.AreEqual("|__|", number.GetNumberSection(NumberSection.Middle, 2));
            Assert.AreEqual("   |", number.GetNumberSection(NumberSection.ScaledMiddleLower, 2));
            Assert.AreEqual("   |", number.GetNumberSection(NumberSection.Bottom, 2));
        }

        [TestMethod]
        public void Value5()
        {
            // ReSharper disable once ObjectCreationAsStatement
            var number = new Number(5);
            Assert.AreEqual(5, number.Value);
            Assert.AreEqual(" _ ", number.GetNumberSection(NumberSection.Top));
            Assert.AreEqual("|_ ", number.GetNumberSection(NumberSection.Middle));
            Assert.AreEqual(" _|", number.GetNumberSection(NumberSection.Bottom));
        }

        [TestMethod]
        public void Value5X2()
        {
            // ReSharper disable once ObjectCreationAsStatement
            var number = new Number(5);
            Assert.AreEqual(5, number.Value);
            Assert.AreEqual(" __ ", number.GetNumberSection(NumberSection.Top, 2));
            Assert.AreEqual("|   ", number.GetNumberSection(NumberSection.ScaledMiddleUpper, 2));
            Assert.AreEqual("|__ ", number.GetNumberSection(NumberSection.Middle, 2));
            Assert.AreEqual("   |", number.GetNumberSection(NumberSection.ScaledMiddleLower , 2));
            Assert.AreEqual(" __|", number.GetNumberSection(NumberSection.Bottom , 2));
        }

        [TestMethod]
        public void Value6()
        {
            // ReSharper disable once ObjectCreationAsStatement
            var number = new Number(6);
            Assert.AreEqual(6, number.Value);
            Assert.AreEqual(" _ ", number.GetNumberSection(NumberSection.Top));
            Assert.AreEqual("|_ ", number.GetNumberSection(NumberSection.Middle));
            Assert.AreEqual("|_|", number.GetNumberSection(NumberSection.Bottom));
        }

        [TestMethod]
        public void Value6X2()
        {
            // ReSharper disable once ObjectCreationAsStatement
            var number = new Number(6);
            Assert.AreEqual(6, number.Value);
            Assert.AreEqual(" __ ", number.GetNumberSection(NumberSection.Top, 2));
            Assert.AreEqual("|   ", number.GetNumberSection(NumberSection.ScaledMiddleUpper, 2));
            Assert.AreEqual("|__ ", number.GetNumberSection(NumberSection.Middle, 2));
            Assert.AreEqual("|  |", number.GetNumberSection(NumberSection.ScaledMiddleLower, 2));
            Assert.AreEqual("|__|", number.GetNumberSection(NumberSection.Bottom, 2));
        }

        [TestMethod]
        public void Value7()
        {
            // ReSharper disable once ObjectCreationAsStatement
            var number = new Number(7);
            Assert.AreEqual(7, number.Value);
            Assert.AreEqual(" _ ", number.GetNumberSection(NumberSection.Top));
            Assert.AreEqual("  |", number.GetNumberSection(NumberSection.Middle));
            Assert.AreEqual("  |", number.GetNumberSection(NumberSection.Bottom));
        }

        [TestMethod]
        public void Value7X2()
        {
            // ReSharper disable once ObjectCreationAsStatement
            var number = new Number(7);
            Assert.AreEqual(7, number.Value);
            Assert.AreEqual(" __ ", number.GetNumberSection(NumberSection.Top, 2));
            Assert.AreEqual("   |", number.GetNumberSection(NumberSection.ScaledMiddleUpper, 2));
            Assert.AreEqual("   |", number.GetNumberSection(NumberSection.Middle, 2));
            Assert.AreEqual("   |", number.GetNumberSection(NumberSection.ScaledMiddleLower, 2));
            Assert.AreEqual("   |", number.GetNumberSection(NumberSection.Bottom, 2));
        }

        [TestMethod]
        public void Value8()
        {
            // ReSharper disable once ObjectCreationAsStatement
            var number = new Number(8);
            Assert.AreEqual(8, number.Value);
            Assert.AreEqual(" _ ", number.GetNumberSection(NumberSection.Top));
            Assert.AreEqual("|_|", number.GetNumberSection(NumberSection.Middle));
            Assert.AreEqual("|_|", number.GetNumberSection(NumberSection.Bottom));
        }

        [TestMethod]
        public void Value8X2()
        {
            // ReSharper disable once ObjectCreationAsStatement
            var number = new Number(8);
            Assert.AreEqual(8, number.Value);
            Assert.AreEqual(" __ ", number.GetNumberSection(NumberSection.Top, 2));
            Assert.AreEqual("|  |", number.GetNumberSection(NumberSection.ScaledMiddleUpper, 2));
            Assert.AreEqual("|__|", number.GetNumberSection(NumberSection.Middle, 2));
            Assert.AreEqual("|  |", number.GetNumberSection(NumberSection.ScaledMiddleLower, 2));
            Assert.AreEqual("|__|", number.GetNumberSection(NumberSection.Bottom, 2));
        }

        [TestMethod]
        public void Value9X2()
        {
            // ReSharper disable once ObjectCreationAsStatement
            var number = new Number(9);
            Assert.AreEqual(9, number.Value);
            Assert.AreEqual(" __ ", number.GetNumberSection(NumberSection.Top, 2));
            Assert.AreEqual("|  |", number.GetNumberSection(NumberSection.ScaledMiddleUpper, 2));
            Assert.AreEqual("|__|", number.GetNumberSection(NumberSection.Middle, 2));
            Assert.AreEqual("   |", number.GetNumberSection(NumberSection.ScaledMiddleLower, 2));
            Assert.AreEqual(" __|", number.GetNumberSection(NumberSection.Bottom, 2));
        }
    }
}