using System.Collections.Generic;
using System.Linq;
using Communication.SignalR.Model;
using Logic.Interface;
using Logic.Model;

namespace Communication.SignalR.Control
{
    public class SignalRGameStateController : IGameStateController
    {
        private readonly SignalRController _signalRController;

        public SignalRGameStateController(SignalRController signalRController)
        {
            _signalRController = signalRController;
        }

        public void SaveGameState(Player player, Game game)
        {
            _signalRController.SaveGameState(game);
        }
        
        public Game GetGame(int gameId)
        {
            return _signalRController.GetGame(gameId);
        }

        public void InitializeHostGameLogic()
        {
            _signalRController.StartHost(); //Start Server
            _signalRController.StartClient(); //Start own client
        }

        public void InitializeJoinGameLogic()
        {
            _signalRController.StartClient();
        }

        public List<int> GetUsedGameIds()
        {
            return TicTacToeSignalRHub.Games.Keys.ToList();
        }
    }
}