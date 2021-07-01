using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumerals.Logic;

namespace RomanNumerals.Test
{
    [TestClass]
    public class UnitTestRomanNumeralToNumber
    {
        [TestMethod]
        public void GenerateAllNumbersAndConvertThemBack()
        {
            var numberKeyValuePair = new Dictionary<int, string>();

            var converter = new NumberToRomanNumeralConverter();
            for (int i = Constants.MinimumNumber; i <= Constants.MaximumNumber; i++)
            {
                numberKeyValuePair.Add(i, converter.ToRomanNumeral(i));
            }

            var converterBack = new RomanNumeralToNumberConverter();
            foreach (var keyValuePair in numberKeyValuePair)
            {
                Assert.AreEqual(keyValuePair.Key, converterBack.ToNumber(keyValuePair.Value));
            }
        }

        [TestMethod]
        public void VariousTestCases()
        {
            var converter = new RomanNumeralToNumberConverter();

            //Based on examples from Wikipedia

            Assert.AreEqual(1, converter.ToNumber("I"));
            Assert.AreEqual(2, converter.ToNumber("II"));
            Assert.AreEqual(3, converter.ToNumber("III"));
            Assert.AreEqual(4, converter.ToNumber("IV"));
            Assert.AreEqual(5, converter.ToNumber("V"));
            Assert.AreEqual(6, converter.ToNumber("VI"));
            Assert.AreEqual(7, converter.ToNumber("VII"));
            Assert.AreEqual(8, converter.ToNumber("VIII"));
            Assert.AreEqual(9, converter.ToNumber("IX"));

            Assert.AreEqual(10, converter.ToNumber("X"));
            Assert.AreEqual(20, converter.ToNumber("XX"));
            Assert.AreEqual(30, converter.ToNumber("XXX"));
            Assert.AreEqual(40, converter.ToNumber("XL"));
            Assert.AreEqual(50, converter.ToNumber("L"));
            Assert.AreEqual(60, converter.ToNumber("LX"));
            Assert.AreEqual(70, converter.ToNumber("LXX"));
            Assert.AreEqual(80, converter.ToNumber("LXXX"));
            Assert.AreEqual(90, converter.ToNumber("XC"));
            Assert.AreEqual(100, converter.ToNumber("C"));

            Assert.AreEqual(100, converter.ToNumber("C"));
            Assert.AreEqual(200, converter.ToNumber("CC"));
            Assert.AreEqual(300, converter.ToNumber("CCC"));
            Assert.AreEqual(400, converter.ToNumber("CD"));
            Assert.AreEqual(500, converter.ToNumber("D"));
            Assert.AreEqual(600, converter.ToNumber("DC"));
            Assert.AreEqual(700, converter.ToNumber("DCC"));
            Assert.AreEqual(800, converter.ToNumber("DCCC"));
            Assert.AreEqual(900, converter.ToNumber("CM"));
            Assert.AreEqual(1000, converter.ToNumber("M"));

            Assert.AreEqual(39, converter.ToNumber("XXXIX"));
            Assert.AreEqual(246, converter.ToNumber("CCXLVI"));
            Assert.AreEqual(207, converter.ToNumber("CCVII"));
            Assert.AreEqual(1066, converter.ToNumber("MLXVI"));

            Assert.AreEqual(1954, converter.ToNumber("MCMLIV"));
            Assert.AreEqual(1990, converter.ToNumber("MCMXC"));
            Assert.AreEqual(2014, converter.ToNumber("MMXIV"));

            Assert.AreEqual(99, converter.ToNumber("XCIX"));
            Assert.AreEqual(999, converter.ToNumber("CMXCIX"));
            Assert.AreEqual(888, converter.ToNumber("DCCCLXXXVIII"));
        }

        [TestMethod]
        public void NullAndEmptyInput()
        {
            var converter = new RomanNumeralToNumberConverter();
            Assert.AreEqual(0, converter.ToNumber(null));
            Assert.AreEqual(0, converter.ToNumber(string.Empty));
            Assert.AreEqual(0, converter.ToNumber(" "));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InvalidInput()
        {
            var converter = new RomanNumeralToNumberConverter();
            converter.ToNumber("ABC");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RightCharsButStillInvalidInput()
        {
            var converter = new RomanNumeralToNumberConverter();
            converter.ToNumber("XCDII");
        }
    }
}