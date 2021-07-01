using Tennis.Logic.Interface;

namespace Tennis.Logic.Model
{
    public class Set : ISet
    {
        private readonly ISetRulesController _setRulesController;
        private readonly IValueTracker _gameTracker;
        public int SetNumber { get; }
        public Player? Winner { get; private set; }

        public Set(ISetRulesController setRulesController, int setNumber)
        {
            SetNumber = setNumber;
            _setRulesController = setRulesController;
            _gameTracker = new ValueTracker();
        }

        public void RegisterGame(Player playerWhoWon)
        {
            _gameTracker.TrackPoint(playerWhoWon);

            var player1Games = _gameTracker.GetPoint(Player.Player1);
            var player2Games = _gameTracker.GetPoint(Player.Player2);
            if (_setRulesController.IsWinningScenario(player1Games, player2Games))
            {
                Winner = playerWhoWon;
            }
        }

        public int GetWonGamesForPlayer(Player player)
        {
            return _gameTracker.GetPoint(player);
        }
    }
}