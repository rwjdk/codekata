namespace Tennis.Logic.Interface
{
    public interface ISetRulesController
    {
        bool IsWinningScenario(int player1Games, int player2Games);
        bool IsTieBreakScenario(int player1Games, int player2Games);
    }
}