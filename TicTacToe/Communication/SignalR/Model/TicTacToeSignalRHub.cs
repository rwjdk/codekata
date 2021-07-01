using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Logic.Model;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Communication.SignalR.Model
{
    [HubName(nameof(TicTacToeSignalRHub))]
    public class TicTacToeSignalRHub : Hub
    {
        internal static readonly Dictionary<int, Game> Games = new Dictionary<int, Game>();

        [UsedImplicitly]
        public void GameStateChanged(Game game)
        {
            if (Games.ContainsKey(game.Id))
            {
                Games[game.Id] = game;
            }
            else
            {
                Games.Add(game.Id, game);
            }
            Clients.All.NotifyChange(game);
        }

        [UsedImplicitly]
        public Game GetGame(int gameId)
        {
            return Games.FirstOrDefault(x => x.Key == gameId).Value;
        }
    }
}