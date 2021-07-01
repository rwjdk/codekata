using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace Tennis.Test.Model
{
    [TestClass]
    public class ValueTrackerTests
    {
        [TestMethod]
        public void NewTrackerHaveZeroValue()
        {
            IValueTracker tracker = new ValueTracker();
            Assert.AreEqual(0, tracker.GetPoint(Player.Player1));
            Assert.AreEqual(0, tracker.GetPoint(Player.Player2));
        }

        [TestMethod]
        public void TrackPoint()
        {
            IValueTracker tracker = new ValueTracker();
            tracker.TrackPoint(Player.Player1);
            Assert.AreEqual(1, tracker.GetPoint(Player.Player1));
            tracker.TrackPoint(Player.Player2);
            Assert.AreEqual(1, tracker.GetPoint(Player.Player2));
        }

        [TestMethod]
        public void ResetTrackerHappen()
        {
            IValueTracker tracker = new ValueTracker();
            tracker.TrackPoint(Player.Player1);
            tracker.TrackPoint(Player.Player2);
            tracker.Reset();
            Assert.AreEqual(0, tracker.GetPoint(Player.Player1));
            Assert.AreEqual(0, tracker.GetPoint(Player.Player2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [ExcludeFromCodeCoverage]
        public void TrackPointOnIncorrectKeyThrowException()
        {
            IValueTracker tracker = new ValueTracker();
            tracker.TrackPoint((Player)666);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [ExcludeFromCodeCoverage]
        public void GetPointOnIncorrectKeyThrowException()
        {
            IValueTracker tracker = new ValueTracker();
            tracker.GetPoint((Player)666);
        }
    }
}