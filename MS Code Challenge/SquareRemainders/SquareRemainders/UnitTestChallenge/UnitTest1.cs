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
            var challenge = new SquareRemainders.Challenge();

            int result = challenge.Execute(25, 1250);

            Assert.AreEqual(650645556, result);
        }
    }
}
