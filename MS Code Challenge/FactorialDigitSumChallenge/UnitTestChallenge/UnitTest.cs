using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestChallenge
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestChallenge()
        {
            var sut = new FactorialDigitSumChallenge.Challenge();

            Assert.AreEqual(27, sut.Execute(10));
            Assert.AreEqual(648, sut.Execute(100));
        }
    }
}