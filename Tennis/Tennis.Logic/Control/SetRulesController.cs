using System;
using Tennis.Logic.Interface;

namespace Tennis.Logic.Control
{
    public class SetRulesController : ISetRulesController
    {
        public bool IsWinningScenario(int player1Games, int player2Games)
        {
            if (IsTieBreakScenario(player1Games, player2Games))
            {
                return IsWinningScenarioInTieBreak(player1Games, player2Games);
            }
            return player1Games == 6 || player2Games == 6;
        }

        private static bool IsWinningScenarioInTieBreak(int player1Games, int player2Games)
        {
            return Math.Abs(player1Games - player2Games) >= 2;
        }

        public bool IsTieBreakScenario(int player1Games, int player2Games)
        {
            return player1Games >= 6 && player2Games >= 5 || player1Games >= 5 && player2Games >= 6;
        }
    }
}