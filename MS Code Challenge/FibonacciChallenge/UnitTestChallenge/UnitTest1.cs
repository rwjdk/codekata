using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestChallenge
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodSolution()
        {

            //* 0,1,1,2,3,5,8,13,21......
            FibonacciChallenge.Challenge f = new FibonacciChallenge.Challenge();
            Assert.IsTrue(f.Fib(1) == 1);
            Assert.IsTrue(f.Fib(2) == 1);
            Assert.IsTrue(f.Fib(3) == 2);
            Assert.IsTrue(f.Fib(4) == 3);
            Assert.IsTrue(f.Fib(5) == 5);
            Assert.IsTrue(f.Fib(42) == 267914296);
        }
    }
}
