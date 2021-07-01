using System;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace Tennis.Logic.Control
{
    public class GameScoreFormatter : IGameScoreFormatter
    {
        public string FormatPoint(GameScoreEnum? gameScore)
        {
            switch (gameScore)
            {
                case GameScoreEnum.Score0:
                    return "0";
                case GameScoreEnum.Score15:
                    return "15";
                case GameScoreEnum.Score30:
                    return "30";
                case GameScoreEnum.Score40:
                    return "40";
                case GameScoreEnum.Advantage:
                    return "Advantage";
                case GameScoreEnum.Deuce:
                    return "Deuce";
                case null:
                    return string.Empty;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}