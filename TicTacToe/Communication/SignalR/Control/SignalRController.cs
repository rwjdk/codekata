using Communication.Properties;
using Communication.SignalR.Model;
using Logic.Model;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.Owin.Hosting;

namespace Communication.SignalR.Control
{
    public class SignalRController
    {
        private HubConnection _hubConnection;
        public IHubProxy HubProxy { get; private set; }

        internal void StartHost()
        {
            WebApp.Start<SignalRStartupConfiguration>(Settings.Default.SignalRUrl);
        }

        internal void StartClient()
        {
            _hubConnection = new HubConnection(Settings.Default.SignalRUrl);
            HubProxy = _hubConnection.CreateHubProxy(nameof(TicTacToeSignalRHub));
            _hubConnection.Start().Wait();
        }

        internal void SaveGameState(Game game)
        {
            HubProxy.Invoke(nameof(TicTacToeSignalRHub.GameStateChanged), game);
        }

        internal Game GetGame(int gameId)
        {
            return HubProxy.Invoke<Game>(nameof(TicTacToeSignalRHub.GetGame), gameId).Result;
        }
    }
}