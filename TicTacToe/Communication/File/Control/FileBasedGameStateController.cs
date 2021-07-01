using System.Collections.Generic;
using Logic.Interface;
using Logic.Model;

namespace Communication.File.Control
{
    public class FileBasedGameStateController : IGameStateController
    {
        private readonly FileBasedController _fileBasedController;

        public FileBasedGameStateController(FileBasedController fileBasedController)
        {
            _fileBasedController = fileBasedController;
        }
        
        public Game GetGame(int gameId)
        {
            return _fileBasedController.ReadFile(gameId, Player.HostingPlayer) ?? _fileBasedController.ReadFile(gameId, Player.JoiningPlayer);
        }

        public void SaveGameState(Player player, Game game)
        {
            _fileBasedController.WriteFile(player, game);
        }

        public void InitializeHostGameLogic()
        {
            //Empty (Nothing need to be initialized)
        }

        public void InitializeJoinGameLogic()
        {
            //Empty (Nothing need to be initialized)
        }

        public List<int> GetUsedGameIds()
        {
            return _fileBasedController.GetUsedGameIds();
        }
    }
}