using System;
using Logic.Controller;
using Logic.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Logic.Control
{
    [TestClass]
    public class StartingPlayerTests
    {
        [TestMethod]
        public void IsStartingPlayerRandom()
        {
            var controller = new StartingPlayerController();
            int numberOfPlayer1Starts = 0;
            int numberOfPlayer2Starts = 0;
            for (int i = 0; i < 10_000; i++)
            {
                var statingPlayer = controller.GetRandomStartingPlayer();
                switch (statingPlayer)
                {
                    case Player.HostingPlayer:
                        numberOfPlayer1Starts++;
                        break;
                    case Player.JoiningPlayer:
                        numberOfPlayer2Starts++;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            Assert.IsTrue(numberOfPlayer1Starts > 0);
            Assert.IsTrue(numberOfPlayer2Starts > 0);
        }
    }
}