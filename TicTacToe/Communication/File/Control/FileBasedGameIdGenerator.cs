using System;
using System.Linq;
using Logic.Interface;

namespace Communication.FileBased.Control
{
    public class FileBasedGameIdGenerator : IGameIdGenerator
    {
        private readonly FileBasedGameStateController _fileBasedGameStateController;

        private readonly Random _random;

        public FileBasedGameIdGenerator(FileBasedGameStateController fileBasedGameStateController)
        {
            _fileBasedGameStateController = fileBasedGameStateController;
            _random = new Random();
        }

        public int GetUniqueGameId()
        {
           var gameFilesInSharedFolder = _fileBasedGameStateController.GetCurrentGameFilesInSharedFolder();

            bool uniqueGameIdNotFound = false;
            int randomGameId = 0;
            while (!uniqueGameIdNotFound)
            {
                randomGameId = _random.Next(0, 1000);
                if (!gameFilesInSharedFolder.Any(x => x.StartsWith(randomGameId.ToString())))
                {
                    uniqueGameIdNotFound = true;
                }
            }

            return randomGameId;
        }
    }
}