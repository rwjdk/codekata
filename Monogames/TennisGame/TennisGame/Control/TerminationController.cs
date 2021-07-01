using Tennis.Logic.Interface;

namespace TennisGame.Control
{
    public class TerminationController : ITerminationController
    {
        private readonly Game _game;

        public TerminationController(Game game)
        {
            _game = game;
        }

        public void TerminateApp()
        {
            _game.Exit();

        }
    }
}