using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Logic.Model;
using Newtonsoft.Json;

namespace Communication.File.Control
{
    public class FileBasedController
    {
        private readonly string _sharedFolder;

        public FileBasedController()
        {
            _sharedFolder = Properties.Settings.Default.SharedFolder;
            if (!Directory.Exists(_sharedFolder))
            {
                Directory.CreateDirectory(_sharedFolder);
            }
        }

        /// <summary>
        /// Read File for specific player
        /// </summary>
        /// <param name="gameId">GameId to find</param>
        /// <param name="player">Player to find</param>
        /// <returns>Game or null if file not found</returns>
        internal Game ReadFile(int gameId, Player player)
        {
            var path = GetPath(gameId, player);
            if (!System.IO.File.Exists(path))
            {
                //File does not exist so return null
                return null;
            }
            
            //Read file and delete it as it should not be read again
            var content = System.IO.File.ReadAllText(path);
            System.IO.File.Delete(path);

            if (string.IsNullOrWhiteSpace(content))
            {
                //File was empty so return null
                return null;
            }
            
            //Deserialize content as a game
            return JsonConvert.DeserializeObject<Game>(content);
        }

        internal void WriteFile(Player player, Game game)
        {
            var content = JsonConvert.SerializeObject(game);

            var path = GetPath(game.Id, player); //Real FilePath

            var tempPath = GetPath(game.Id, player, true); //Temp filePath

            System.IO.File.WriteAllText(tempPath, content); //Write content of temp file

            System.IO.File.Delete(path); //Delete any existing file the might be

            System.IO.File.Move(tempPath, path); //Turn temp file into real file
        }

        /// <summary>
        /// Get currently used gameIds
        /// </summary>
        /// <returns>List of gameIds that are already used</returns>
        internal List<int> GetUsedGameIds()
        {
            var result = new List<int>();
            var filePaths = Directory.GetFiles(_sharedFolder, "*_*.json");

            foreach (var filePath in filePaths)
            {
                var fileName = Path.GetFileName(filePath);
                var indexOf = fileName.IndexOf("_", StringComparison.Ordinal);
                var substring = fileName.Substring(0, indexOf);
                if (int.TryParse(substring, NumberStyles.None, CultureInfo.InvariantCulture, out var gameId))
                {
                    result.Add(gameId);
                }
            }
            return result;
        }

        private string GetPath(int gameId, Player player, bool tmpFile = false)
        {
            var extension = tmpFile ? "tmp" : "json"; //Get either a temp file or json file (to ensure file is not read while written)
            return Path.Combine(_sharedFolder, $"{gameId}_{Convert.ToInt32(player)}.{extension}");
        }
    }
}