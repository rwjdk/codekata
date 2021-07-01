using System;
using System.Diagnostics.CodeAnalysis;
using Logic.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Model
{
    [TestClass]
    public class FrameTests
    {
        [TestMethod]
        public void FrameWithOnlyFirstShotTake()
        {
            var game = new Game();
            var frame = game.Frame1;
            frame.RegisterShot(ShotResult.Score3);
            Assert.IsFalse(frame.IsFrameOver);

            var frameResult = frame.GetFrameScore();
            Assert.AreEqual(3, frameResult.Score);
            Assert.AreEqual("[3][ ]", frameResult.Description);
        }

        [TestMethod]
        public void FrameWithNoScore()
        {
            var game = new Game();
            var frame = game.Frame1;
            frame.RegisterShot(ShotResult.Score0);
            Assert.IsFalse(frame.IsFrameOver);
            frame.RegisterShot(ShotResult.Score0);
            Assert.IsTrue(frame.IsFrameOver);

            var frameResult = frame.GetFrameScore();
            Assert.AreEqual(0, frameResult.Score);
            Assert.AreEqual("[0][0]", frameResult.Description);
        }

        [TestMethod]
        public void FrameWithNormalScore()
        {
            var game = new Game();
            var frame = game.Frame1;
            frame.RegisterShot(ShotResult.Score1);
            Assert.IsFalse(frame.IsFrameOver);
            frame.RegisterShot(ShotResult.Score4);
            Assert.IsTrue(frame.IsFrameOver);

            var frameResult = frame.GetFrameScore();
            Assert.AreEqual(5, frameResult.Score);
            Assert.AreEqual("[1][4]", frameResult.Description);
        }

        [TestMethod]
        public void FrameWithStrikeButNextFramesAreNotComplete()
        {
            var game = new Game();
            var frame = game.Frame1;
            frame.RegisterShot(ShotResult.Score10);
            Assert.IsTrue(frame.IsFrameOver);
            Assert.IsTrue(frame.IsStrike);

            var frameResult = frame.GetFrameScore();
            Assert.AreEqual(null, frameResult.Score);
            Assert.AreEqual("[X][-]", frameResult.Description);
        }

        [TestMethod]
        public void FrameWithStrikAndStrikeButNextFrameIsNotComplete()
        {
            var game = new Game();
            var frame1 = game.Frame1;
            frame1.RegisterShot(ShotResult.Score10);
            Assert.IsTrue(frame1.IsFrameOver);
            Assert.IsTrue(frame1.IsStrike);

            var frame2 = game.Frame2;
            frame2.RegisterShot(ShotResult.Score10);

            var frameResult = frame1.GetFrameScore();
            Assert.AreEqual(null, frameResult.Score);
            Assert.AreEqual("[X][-]", frameResult.Description);
        }

        [TestMethod]
        public void FrameWithTripleStrike()
        {
            var game = new Game();
            var frame1 = game.Frame1;
            frame1.RegisterShot(ShotResult.Score10);

            var frame2 = game.Frame2;
            frame2.RegisterShot(ShotResult.Score10);

            var frame3 = game.Frame3;
            frame3.RegisterShot(ShotResult.Score10);

            var frameResult = frame1.GetFrameScore();
            Assert.AreEqual(30, frameResult.Score);
            Assert.AreEqual("[X][-]", frameResult.Description);
        }

        [TestMethod]
        public void FrameWithSpareButNextFrameIsNotComplete()
        {
            var game = new Game();
            var frame = game.Frame1;
            frame.RegisterShot(ShotResult.Score5);
            Assert.IsFalse(frame.IsFrameOver);
            frame.RegisterShot(ShotResult.Score5);
            Assert.IsTrue(frame.IsFrameOver);
            Assert.IsTrue(frame.IsSpare);

            var frameResult = frame.GetFrameScore();
            Assert.AreEqual(null, frameResult.Score);
            Assert.AreEqual("[5][/]", frameResult.Description);
        }

        [TestMethod]
        public void LastFrameWithSpare()
        {
            var game = new Game();
            var frame = game.Frame10;
            frame.RegisterShot(ShotResult.Score5);
            Assert.IsFalse(frame.IsFrameOver);
            frame.RegisterShot(ShotResult.Score5);
            Assert.IsTrue(frame.IsFrameOver);
            Assert.IsTrue(frame.IsSpare);

            game.Frame10Bonus1.RegisterShot(ShotResult.Score5);

            var frameResult = frame.GetFrameScore();
            Assert.AreEqual(15, frameResult.Score);
            Assert.AreEqual("[5][/]", frameResult.Description);
        }

        [TestMethod]
        public void LastFrameWithStrike()
        {
            var game = new Game();
            game.Frame10.RegisterShot(ShotResult.Score10);
            Assert.IsTrue(game.Frame10.IsFrameOver);
            Assert.IsTrue(game.Frame10.IsStrike);
            game.Frame10Bonus1.RegisterShot(ShotResult.Score10);
            Assert.IsTrue(game.Frame10Bonus1.IsFrameOver);
            Assert.IsTrue(game.Frame10Bonus1.IsStrike);

            game.Frame10Bonus2.RegisterShot(ShotResult.Score10);
            Assert.IsTrue(game.Frame10Bonus2.IsFrameOver);
            Assert.IsTrue(game.Frame10Bonus2.IsStrike);

            var frameResult = game.Frame10.GetFrameScore();
            Assert.AreEqual(30, frameResult.Score);
            Assert.AreEqual("[X][-]", frameResult.Description);
        }

        [TestMethod]
        public void LastFrameWithStrikeAndSpareInBonus()
        {
            var game = new Game();
            game.Frame10.RegisterShot(ShotResult.Score10);
            Assert.IsTrue(game.Frame10.IsFrameOver);
            Assert.IsTrue(game.Frame10.IsStrike);
            game.Frame10Bonus1.RegisterShot(ShotResult.Score5);
            Assert.IsFalse(game.Frame10Bonus1.IsFrameOver);
            game.Frame10Bonus1.RegisterShot(ShotResult.Score5);
            Assert.IsTrue(game.Frame10Bonus1.IsFrameOver);
            Assert.IsTrue(game.Frame10Bonus1.IsSpare);

            var frameResult = game.Frame10.GetFrameScore();
            Assert.AreEqual(20, frameResult.Score);
            Assert.AreEqual("[X][-]", frameResult.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [ExcludeFromCodeCoverage]
        public void ThreeShotsInFrameThrowException()
        {
            var game = new Game();
            game.Frame1.RegisterShot(ShotResult.Score0);
            game.Frame1.RegisterShot(ShotResult.Score0);
            game.Frame1.RegisterShot(ShotResult.Score0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [ExcludeFromCodeCoverage]
        public void CreateFrameWithInvalidNumberThrowException()
        {
            // ReSharper disable once UnusedVariable
            var frame = new Frame(99, null, null);
        }
    }
}