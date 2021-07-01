using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestChallenge
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var challenge = new BingMapsChallenge.Challenge();

            var resultArray = challenge.Execute("Frydenlunds Alle 6", "2950", "DK");

            Assert.AreEqual(55.8408508, resultArray[0]);
            Assert.AreEqual(12.5594797, resultArray[1]);
        }
    }
}
