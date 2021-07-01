using Tennis.Logic.Model;

namespace Tennis.Logic.Interface
{
    public interface ISet
    {
        int SetNumber { get; }
        Player? Winner { get; }
        void RegisterGame(Player playerWhoWon);
        int GetWonGamesForPlayer(Player player);
    }
}