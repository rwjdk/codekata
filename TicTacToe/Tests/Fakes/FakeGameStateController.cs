using System.Collections.Generic;
using Logic.Interface;
using Logic.Model;

namespace Tests.Fakes
{
    public class FakeGameStateController : IGameStateController
    {
        private Game _game;

        public Game GetGame(int gameId)
        {
            if (_game == null)
            {
                if (gameId == 0)
                {
                    return null;
                }
                return Game.CreateNewGame(Player.HostingPlayer, 1234);
            }

            return _game;
        }

        public void SaveGameState(Player player, Game game)
        {
            _game = game;
        }

        public void InitializeHostGameLogic()
        {
            //Empty
        }

        public void InitializeJoinGameLogic()
        {
            //Empty
        }

        public List<int> GetUsedGameIds()
        {
            return new List<int>();
        }
    }
}