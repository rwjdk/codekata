using Tennis.Logic.Model;

namespace Tennis.Logic.Interface
{
    public interface ISet
    {
        Player? Winner { get; }
        void RegisterGame(Player playerWhoWon);
        int GetWonGamesForPlayer(Player player);
    }
}