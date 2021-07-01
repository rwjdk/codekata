using System;
using Tennis.Logic.Interface;

namespace Tennis.Logic.Control
{
    /// <summary>
    /// Point to Tennis score cheat cheat
    /// 0 = 0
    /// 1 = 15
    /// 2 = 30
    /// 3 = 40
    /// (Beyond that Deuce and Advantage take over (Tie-break-rules))
    /// </summary>
    public class GameRulesController : IGameRulesController
    {
        public bool IsWinningScenario(int player1Points, int player2Points)
        {
            if (IsTieBreakScenario(player1Points, player2Points))
            {
                return IsWinningScenarioInTieBreak(player1Points, player2Points);
            }
            return player1Points > 3 || player2Points > 3;
        }

        private static bool IsWinningScenarioInTieBreak(int player1Points, int player2Points)
        {
            var diff = player1Points - player2Points;
            if (Math.Abs(diff) >= 2)
            {
                return true;
            }
            return false;
        }

        public bool IsTieBreakScenario(int player1Points, int player2Points)
        {
            return player1Points >= 3 && player2Points >= 3;
        }
    }
}