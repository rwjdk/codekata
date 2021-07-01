using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace Tennis.Test.Control
{
    [TestClass]
    public class GameScoreFormatterTests
    {
        [TestMethod]
        public void FormattingOfTheVariousValues()
        {
            var formatter = DependencyInjection.Resolve<IGameScoreFormatter>();

            Assert.AreEqual("", formatter.FormatPoint(null));
            Assert.AreEqual("0", formatter.FormatPoint(GameScoreEnum.Score0));
            Assert.AreEqual("15", formatter.FormatPoint(GameScoreEnum.Score15));
            Assert.AreEqual("30", formatter.FormatPoint(GameScoreEnum.Score30));
            Assert.AreEqual("40", formatter.FormatPoint(GameScoreEnum.Score40));
            Assert.AreEqual("Advantage", formatter.FormatPoint(GameScoreEnum.Advantage));
            Assert.AreEqual("Deuce", formatter.FormatPoint(GameScoreEnum.Deuce));
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InvalidValueThrowException()
        {
            var formatter = DependencyInjection.Resolve<IGameScoreFormatter>();

            Assert.AreEqual("", formatter.FormatPoint((GameScoreEnum?)999));
        }
    }
}