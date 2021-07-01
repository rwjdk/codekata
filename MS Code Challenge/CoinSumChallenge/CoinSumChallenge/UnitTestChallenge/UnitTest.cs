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
            var sut = new CoinSumChallenge.Challenge();

            var fiftyPence = 50;
            var twoPounds = 200;

            Assert.AreEqual(451, sut.Exuecute(fiftyPence));
            Assert.AreEqual(73682, sut.Exuecute(twoPounds));
        }
    }
}