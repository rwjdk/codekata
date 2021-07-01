using System.Collections.Generic;
using Logic.Model;

namespace Logic.Interface
{
    public interface IGameStateController
    {
        List<int> GetUsedGameIds();
        Game GetGame(int gameId);
        void SaveGameState(Player player, Game game);
        void InitializeHostGameLogic();
        void InitializeJoinGameLogic();
    }
}