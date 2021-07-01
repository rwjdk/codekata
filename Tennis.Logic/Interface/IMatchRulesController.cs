namespace Tennis.Logic.Interface
{
    public interface IMatchRulesController
    {
        bool IsWinningScenario(int numberOfSets, int player1Sets, int player2Sets);
    }
}