using Tennis.Logic.Model;

namespace Tennis.Logic.Interface
{
    public interface IGameScore
    {
        GameScoreEnum? GetScoreForPlayer(Player player);
        bool Equals(IGameScore other);
        bool Equals(object obj);
        int GetHashCode();
    }
}