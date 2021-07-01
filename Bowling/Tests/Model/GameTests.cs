using System;
using System.Diagnostics.CodeAnalysis;
using Logic.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Model
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void NoShotsTaken()
        {
            var game = new Game();
            Assert.AreEqual(0, game.GetOverallScore());
        }

        [TestMethod]
        public void All0Game()
        {
            var game = new Game();
            GameNextAction gameNextAction = GameNextAction.ContinueShooting;
            while (gameNextAction == GameNextAction.ContinueShooting)
            {
                gameNextAction = game.RegisterShot(ShotResult.Score0);
            }
            Assert.AreEqual(0, game.GetOverallScore());
        }

        [TestMethod]
        public void All1And0Game()
        {
            var game = new Game();
            GameNextAction gameNextAction = GameNextAction.ContinueShooting;
            while (gameNextAction == GameNextAction.ContinueShooting)
            {
                game.RegisterShot(ShotResult.Score1);
                gameNextAction = game.RegisterShot(ShotResult.Score0);
            }
            Assert.AreEqual(10, game.GetOverallScore());
        }

        [TestMethod]
        public void All1Game()
        {
            var game = new Game();
            GameNextAction gameNextAction = GameNextAction.ContinueShooting;
            while (gameNextAction == GameNextAction.ContinueShooting)
            {
                gameNextAction = game.RegisterShot(ShotResult.Score1);
            }
            Assert.AreEqual(20, game.GetOverallScore());
        }

        [TestMethod]
        public void All2Game()
        {
            var game = new Game();
            GameNextAction gameNextAction = GameNextAction.ContinueShooting;
            while (gameNextAction == GameNextAction.ContinueShooting)
            {
                gameNextAction = game.RegisterShot(ShotResult.Score2);
            }
            Assert.AreEqual(40, game.GetOverallScore());
        }

        [TestMethod]
        public void All3Game()
        {
            var game = new Game();
            GameNextAction gameNextAction = GameNextAction.ContinueShooting;
            while (gameNextAction == GameNextAction.ContinueShooting)
            {
                gameNextAction = game.RegisterShot(ShotResult.Score3);
            }
            Assert.AreEqual(60, game.GetOverallScore());
        }

        [TestMethod]
        public void All4Game()
        {
            var game = new Game();
            GameNextAction gameNextAction = GameNextAction.ContinueShooting;
            while (gameNextAction == GameNextAction.ContinueShooting)
            {
                gameNextAction = game.RegisterShot(ShotResult.Score4);
            }
            Assert.AreEqual(80, game.GetOverallScore());
        }

        [TestMethod]
        public void All5GameAkaSparesAndAFive()
        {
            var game = new Game();
            GameNextAction gameNextAction = GameNextAction.ContinueShooting;
            while (gameNextAction == GameNextAction.ContinueShooting)
            {
                gameNextAction = game.RegisterShot(ShotResult.Score5);
            }
            Assert.AreEqual(150, game.GetOverallScore());
        }

        [TestMethod]
        public void All6And0Game()
        {
            var game = new Game();
            GameNextAction gameNextAction = GameNextAction.ContinueShooting;
            while (gameNextAction == GameNextAction.ContinueShooting)
            {
                game.RegisterShot(ShotResult.Score6);
                gameNextAction = game.RegisterShot(ShotResult.Score0);
            }
            Assert.AreEqual(60, game.GetOverallScore());
        }

        [TestMethod]
        public void All7And0Game()
        {
            var game = new Game();
            GameNextAction gameNextAction = GameNextAction.ContinueShooting;
            while (gameNextAction == GameNextAction.ContinueShooting)
            {
                game.RegisterShot(ShotResult.Score7);
                gameNextAction = game.RegisterShot(ShotResult.Score0);
            }
            Assert.AreEqual(70, game.GetOverallScore());
        }

        [TestMethod]
        public void All8And0Game()
        {
            var game = new Game();
            GameNextAction gameNextAction = GameNextAction.ContinueShooting;
            while (gameNextAction == GameNextAction.ContinueShooting)
            {
                game.RegisterShot(ShotResult.Score8);
                gameNextAction = game.RegisterShot(ShotResult.Score0);
            }
            Assert.AreEqual(80, game.GetOverallScore());
        }

        [TestMethod]
        public void All9And0Game()
        {
            var game = new Game();
            GameNextAction gameNextAction = GameNextAction.ContinueShooting;
            while (gameNextAction == GameNextAction.ContinueShooting)
            {
                game.RegisterShot(ShotResult.Score9);
                gameNextAction = game.RegisterShot(ShotResult.Score0);
            }
            Assert.AreEqual(90, game.GetOverallScore());
        }

        [TestMethod]
        public void AllStrikeGame()
        {
            var game = new Game();
            GameNextAction gameNextAction = GameNextAction.ContinueShooting;
            while (gameNextAction == GameNextAction.ContinueShooting)
            {
                gameNextAction = game.RegisterShot(ShotResult.Score10);
            }
            Assert.AreEqual(300, game.GetOverallScore());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        [ExcludeFromCodeCoverage]
        public void ShotResultIsInvalidTooHigh()
        {
            var game = new Game();
            game.RegisterShot((ShotResult) 11);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        [ExcludeFromCodeCoverage]
        public void ShotResultIsInvalidTooLow()
        {
            var game = new Game();
            game.RegisterShot((ShotResult) (-1));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        [ExcludeFromCodeCoverage]
        public void SecondsShotResultIsInvalidTotalFrameScore()
        {
            var game = new Game();
            game.RegisterShot(ShotResult.Score8);
            game.RegisterShot(ShotResult.Score3);
        }
    }
}