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
            var sut = new PowerSumChallenge.Challenge();
            
            Assert.AreEqual(7, sut.Execute(10));
            Assert.AreEqual(115, sut.Execute(100));
        }
    }
}
