using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestChallenge
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var challenge = new GroupByChallenge.Challenge();

            var input = new object[]
            { 
                "Hello",
                123,
                true,
                false,
                true,
                "Microsoft",
                89.67,
                '@'
            };

            var result = challenge.Execute(input);

            Assert.IsInstanceOfType(result, typeof(Dictionary<Type, int>));
            Assert.AreEqual(result.Count, 5);
            Assert.AreEqual(result[typeof(string)], 2);
            Assert.AreEqual(result[typeof(int)], 1);
            Assert.AreEqual(result[typeof(bool)], 3);
            Assert.AreEqual(result[typeof(double)], 1);
            Assert.AreEqual(result[typeof(char)], 1);
        }
    }
}
