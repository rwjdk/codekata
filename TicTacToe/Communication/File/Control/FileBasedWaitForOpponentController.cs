using System;
using System.Timers;
using Logic.Interface;
using Logic.Model;

namespace Communication.File.Control
{
    public class FileBasedWaitForOpponentController : IWaitForOpponentController
    {
        private readonly FileBasedController _fileBasedController;
        private int _gameId;
        private PlayerViewModel _me;
        public event Action<Game> MyTurn;

        public FileBasedWaitForOpponentController(FileBasedController fileBasedController, int interval = 500)
        {
            _fileBasedController = fileBasedController;
            var timer = new Timer { Interval = interval };
            timer.Elapsed += TimerOnElapsed;
            timer.Start();
        }

        public void Initialize(int gameId, PlayerViewModel me)
        {
            _gameId = gameId;
            _me = me;
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            if (_gameId == 0 || _me == null)
            {
                return;
            }
            var game = _fileBasedController.ReadFile(_gameId, _me.Player);
            if (game != null)
            {
                //A file exist for me so it must be my turn (Raise event)
                MyTurn?.Invoke(game);
            }
        }


    }
}