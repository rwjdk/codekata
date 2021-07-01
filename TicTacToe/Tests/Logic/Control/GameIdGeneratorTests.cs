using System;
using System.Collections.Generic;
using Logic.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Logic.Control
{
    [TestClass]
    public class GameIdGeneratorTests
    {
        [TestMethod]
        public void TestThatGameIdIsUnique()
        {
            var gameIdGenerator = new GameIdGenerator();
            var used = new List<int>();
            for (int i = 0; i < GameIdGenerator.MaxValue; i++)
            {
                var gameId = gameIdGenerator.GetUniqueGameId(used);
                Assert.IsFalse(used.Contains(gameId));
                used.Add(gameId);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestThatIfAll999GameIdsAreInUseExceptionIsThrown()
        {
            var gameIdGenerator = new GameIdGenerator();
            var used = new List<int>();
            for (int i = 0; i < GameIdGenerator.MaxValue+1; i++)
            {
                var gameId = gameIdGenerator.GetUniqueGameId(used);
                Assert.IsFalse(used.Contains(gameId));
                used.Add(gameId);
            }
        }
    }
}