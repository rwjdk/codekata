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
            var sut = new CountingMondays.Challenge();

            Assert.AreEqual(19, sut.Execute(1990, 1999));
            Assert.AreEqual(10, sut.Execute(1999, 2003));
        }
    }
}
