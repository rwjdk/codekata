using Tennis.Logic.Interface;

namespace Tennis.Logic.Control
{
    public class MatchRulesController : IMatchRulesController
    {
        public bool IsWinningScenario(int numberOfSets, int player1Sets, int player2Sets)
        {
            var neededSetsToWin = (numberOfSets / 2);
            return player1Sets > neededSetsToWin || player2Sets > neededSetsToWin;
        }
    }
}