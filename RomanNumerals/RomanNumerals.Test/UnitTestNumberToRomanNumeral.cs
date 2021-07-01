using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumerals.Logic;

namespace RomanNumerals.Test
{
    [TestClass]
    public class UnitTestNumberToRomanNumeral
    {
        [TestMethod]
        public void CanConvertAllNumbersBetween1And3999()
        {
            var converter = new NumberToRomanNumeralConverter();
            for (int i = Constants.MinimumNumber; i <= Constants.MaximumNumber; i++)
            {
                converter.ToRomanNumeral(i);
            }
        }

        [TestMethod]
        public void VariousTestCases()
        {
            var converter = new NumberToRomanNumeralConverter();

            //Based on examples from Wikipedia

            Assert.AreEqual("I", converter.ToRomanNumeral(1));
            Assert.AreEqual("II", converter.ToRomanNumeral(2));
            Assert.AreEqual("III", converter.ToRomanNumeral(3));
            Assert.AreEqual("IV", converter.ToRomanNumeral(4));
            Assert.AreEqual("V", converter.ToRomanNumeral(5));
            Assert.AreEqual("VI", converter.ToRomanNumeral(6));
            Assert.AreEqual("VII", converter.ToRomanNumeral(7));
            Assert.AreEqual("VIII", converter.ToRomanNumeral(8));
            Assert.AreEqual("IX", converter.ToRomanNumeral(9));

            Assert.AreEqual("X", converter.ToRomanNumeral(10));
            Assert.AreEqual("XX", converter.ToRomanNumeral(20));
            Assert.AreEqual("XXX", converter.ToRomanNumeral(30));
            Assert.AreEqual("XL", converter.ToRomanNumeral(40));
            Assert.AreEqual("L", converter.ToRomanNumeral(50));
            Assert.AreEqual("LX", converter.ToRomanNumeral(60));
            Assert.AreEqual("LXX", converter.ToRomanNumeral(70));
            Assert.AreEqual("LXXX", converter.ToRomanNumeral(80));
            Assert.AreEqual("XC", converter.ToRomanNumeral(90));
            Assert.AreEqual("C", converter.ToRomanNumeral(100));

            Assert.AreEqual("C", converter.ToRomanNumeral(100));
            Assert.AreEqual("CC", converter.ToRomanNumeral(200));
            Assert.AreEqual("CCC", converter.ToRomanNumeral(300));
            Assert.AreEqual("CD", converter.ToRomanNumeral(400));
            Assert.AreEqual("D", converter.ToRomanNumeral(500));
            Assert.AreEqual("DC", converter.ToRomanNumeral(600));
            Assert.AreEqual("DCC", converter.ToRomanNumeral(700));
            Assert.AreEqual("DCCC", converter.ToRomanNumeral(800));
            Assert.AreEqual("CM", converter.ToRomanNumeral(900));
            Assert.AreEqual("M", converter.ToRomanNumeral(1000));

            Assert.AreEqual("XXXIX", converter.ToRomanNumeral(39));
            Assert.AreEqual("CCXLVI", converter.ToRomanNumeral(246));
            Assert.AreEqual("CCVII", converter.ToRomanNumeral(207));
            Assert.AreEqual("MLXVI", converter.ToRomanNumeral(1066));

            Assert.AreEqual("MCMLIV", converter.ToRomanNumeral(1954));
            Assert.AreEqual("MCMXC", converter.ToRomanNumeral(1990));
            Assert.AreEqual("MMXIV", converter.ToRomanNumeral(2014));

            Assert.AreEqual("XCIX", converter.ToRomanNumeral(99));
            Assert.AreEqual("CMXCIX", converter.ToRomanNumeral(999));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TooLowValue()
        {
            var converter = new NumberToRomanNumeralConverter();
            converter.ToRomanNumeral(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TooHighValue()
        {
            var converter = new NumberToRomanNumeralConverter();
            converter.ToRomanNumeral(4000);
        }
    }
}

