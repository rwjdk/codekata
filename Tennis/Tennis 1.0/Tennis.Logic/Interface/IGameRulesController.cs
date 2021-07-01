namespace Tennis.Logic.Interface
{
    public interface IGameRulesController
    {
        bool IsWinningScenario(int player1Points, int player2Points);
        bool IsTieBreakScenario(int player1Points, int player2Points);
    }
}