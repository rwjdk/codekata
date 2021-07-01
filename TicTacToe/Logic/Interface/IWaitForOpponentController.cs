using System;
using Logic.Model;

namespace Logic.Interface
{
    public interface IWaitForOpponentController
    {
        void Initialize(int gameId, PlayerViewModel me);
        event Action<Game> MyTurn;
    }
}