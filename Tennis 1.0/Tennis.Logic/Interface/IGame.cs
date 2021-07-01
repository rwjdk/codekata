using Tennis.Logic.Model;

namespace Tennis.Logic.Interface
{
    public interface IGame
    {
        Player? Winner { get; }
        void RegisterPoint(Player playerWhoWonThePoint);
        IGameScore GetGameScore();
        void Reset();
    }
}