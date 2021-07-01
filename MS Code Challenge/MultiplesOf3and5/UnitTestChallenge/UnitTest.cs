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
            var sut = new MultiplesOf3and5.Challenge();

            Assert.AreEqual(23, sut.Execute(10));
            Assert.AreEqual(2318, sut.Execute(100));
        }
    }
}
