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
            var sut = new SumSquareDifferenceChallenge.Challenge();

            Assert.AreEqual(2640, sut.Execute(10));
            Assert.AreEqual(25164150, sut.Execute(100));
        }
    }
}
