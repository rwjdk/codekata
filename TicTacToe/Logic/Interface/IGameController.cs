using System;
using Logic.Model;

namespace Logic.Interface
{
    public interface IGameController
    {
        int HostGame();
        void JoinGame(int gameId);
        void MakeMove(int row, int column);
        bool IsItMyTurn();
        event Action<PlayerViewModel> WhoYouAreIdentified;
        event Action<NextPlayersTurnEventArgs> NextPlayersTurn;
        event Action<GameEndedEventArgs> GameEnded;
    }
}