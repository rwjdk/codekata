using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumerals.Logic;

namespace RomanNumerals.Test
{
    [TestClass]
    public class UnitTestNumberGroupToRomanNumeralConverter
    {
        [TestMethod]
        public void OnesGroupGiveValidResult()
        {
            var group = NumberGroupToRomanNumeralConverter.GenerateOnesGroup();
            Assert.AreEqual(1, group.Factor);
            Assert.AreEqual("", group.GetNumberGroupValue(0));
            Assert.AreEqual("I", group.GetNumberGroupValue(1));
            Assert.AreEqual("II", group.GetNumberGroupValue(2));
            Assert.AreEqual("III", group.GetNumberGroupValue(3));
            Assert.AreEqual("IV", group.GetNumberGroupValue(4));
            Assert.AreEqual("V", group.GetNumberGroupValue(5));
            Assert.AreEqual("VI", group.GetNumberGroupValue(6));
            Assert.AreEqual("VII", group.GetNumberGroupValue(7));
            Assert.AreEqual("VIII", group.GetNumberGroupValue(8));
            Assert.AreEqual("IX", group.GetNumberGroupValue(9));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OnesGroupGiveInvalidResult()
        {
            var group = NumberGroupToRomanNumeralConverter.GenerateOnesGroup();
            group.GetNumberGroupValue(10);
        }

        [TestMethod]
        public void TensGroupGiveValidResult()
        {
            var group = NumberGroupToRomanNumeralConverter.GenerateTensGroup();
            Assert.AreEqual(10, group.Factor);
            Assert.AreEqual("", group.GetNumberGroupValue(0));
            Assert.AreEqual("X", group.GetNumberGroupValue(1));
            Assert.AreEqual("XX", group.GetNumberGroupValue(2));
            Assert.AreEqual("XXX", group.GetNumberGroupValue(3));
            Assert.AreEqual("XL", group.GetNumberGroupValue(4));
            Assert.AreEqual("L", group.GetNumberGroupValue(5));
            Assert.AreEqual("LX", group.GetNumberGroupValue(6));
            Assert.AreEqual("LXX", group.GetNumberGroupValue(7));
            Assert.AreEqual("LXXX", group.GetNumberGroupValue(8));
            Assert.AreEqual("XC", group.GetNumberGroupValue(9));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TensGroupGiveInvalidResult()
        {
            var group = NumberGroupToRomanNumeralConverter.GenerateTensGroup();
            group.GetNumberGroupValue(10);
        }

        [TestMethod]
        public void HundredsGroupGiveValidResult()
        {
            var group = NumberGroupToRomanNumeralConverter.GenerateHundresGroup();
            Assert.AreEqual(100, group.Factor);
            Assert.AreEqual("", group.GetNumberGroupValue(0));
            Assert.AreEqual("C", group.GetNumberGroupValue(1));
            Assert.AreEqual("CC", group.GetNumberGroupValue(2));
            Assert.AreEqual("CCC", group.GetNumberGroupValue(3));
            Assert.AreEqual("CD", group.GetNumberGroupValue(4));
            Assert.AreEqual("D", group.GetNumberGroupValue(5));
            Assert.AreEqual("DC", group.GetNumberGroupValue(6));
            Assert.AreEqual("DCC", group.GetNumberGroupValue(7));
            Assert.AreEqual("DCCC", group.GetNumberGroupValue(8));
            Assert.AreEqual("CM", group.GetNumberGroupValue(9));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HundredsGroupGiveInvalidResult()
        {
            var group = NumberGroupToRomanNumeralConverter.GenerateHundresGroup();
            group.GetNumberGroupValue(10);
        }
    }
}