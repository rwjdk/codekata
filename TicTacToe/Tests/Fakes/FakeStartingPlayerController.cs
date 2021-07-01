using Logic.Interface;
using Logic.Model;

namespace Tests.Fakes
{
    public class FakeStartingPlayerController : IStartingPlayerController
    {
        private readonly Player _playerThatShouldBeFirstPlayer;

        public FakeStartingPlayerController(Player playerThatShouldBeFirstPlayer)
        {
            _playerThatShouldBeFirstPlayer = playerThatShouldBeFirstPlayer;
        }

        public Player GetRandomStartingPlayer()
        {
            return _playerThatShouldBeFirstPlayer;
        }
    }
}