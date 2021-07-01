namespace Tennis.Logic.Interface
{
    public interface ISetRulesController
    {
        bool IsWinningScenario(int gamesPlayer1HaveWon, int gamesPlayer2HaveWon);
        bool IsTieBreakScenario(int player1Games, int player2Games);
    }
}