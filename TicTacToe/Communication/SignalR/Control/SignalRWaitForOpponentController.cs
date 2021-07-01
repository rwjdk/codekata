using System;
using Logic.Interface;
using Logic.Model;
using Microsoft.AspNet.SignalR.Client;

namespace Communication.SignalR.Control
{
    public class SignalRWaitForOpponentController : IWaitForOpponentController
    {
        private readonly SignalRController _signalRController;
        private int _gameId;
        private PlayerViewModel _me;

        public SignalRWaitForOpponentController(SignalRController signalRController)
        {
            _signalRController = signalRController;
        }

        public void Initialize(int gameId, PlayerViewModel me)
        {
            _gameId = gameId;
            _me = me;
            StartListening();
        }

        private void StartListening()
        {
            _signalRController.HubProxy.On<Game>("NotifyChange", game =>
            {
                if (_gameId == game.Id && game.NextPlayer == _me.Player)
                {
                    MyTurn?.Invoke(game);
                }
            });
        }

        public event Action<Game> MyTurn;
    }
}