﻿namespace Tennis.Logic.Interface
{
    public interface IGameScoreController
    {
        IGameScore GetGameScore(int player1Points, int player2Points);
    }
}