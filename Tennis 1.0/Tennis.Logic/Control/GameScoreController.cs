using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace Tennis.Logic.Control
{
    public class GameScoreController : IGameScoreController
    {
        private readonly IGameRulesController _gameRulesController;

        public GameScoreController(IGameRulesController gameRulesController)
        {
            _gameRulesController = gameRulesController;
        }

        public IGameScore GetGameScore(int player1Points, int player2Points)
        {
            if (_gameRulesController.IsWinningScenario(player1Points, player2Points))
            {
                return new GameScore(null, null);
            }

            if (_gameRulesController.IsTieBreakScenario(player1Points, player2Points))
            {
                if (player1Points > player2Points)
                {
                    return new GameScore(GameScoreEnum.Advantage, null);
                }
                if (player2Points > player1Points)
                {
                    return new GameScore(null, GameScoreEnum.Advantage);
                }
                return new GameScore(GameScoreEnum.Deuce, GameScoreEnum.Deuce);
            }

            return new GameScore((GameScoreEnum)player1Points, (GameScoreEnum)player2Points);
        }
    }
}