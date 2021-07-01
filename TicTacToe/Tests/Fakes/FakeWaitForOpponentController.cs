using System;
using Logic.Interface;
using Logic.Model;

namespace Tests.Fakes
{
    public class FakeWaitForOpponentController : IWaitForOpponentController
    {
        public void Initialize(int gameId, PlayerViewModel me)
        {
            //Empty
        }

        public event Action<Game> MyTurn;
        
    }
}