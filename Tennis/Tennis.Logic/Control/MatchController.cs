using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace Tennis.Logic.Control
{
    public class MatchController : IMatchController
    {
        private readonly IGameScoreController _gameScoreController;
        private readonly ISetRulesController _setRulesController;
        private readonly IMatchRulesController _matchRulesController;

        public MatchController(IGameScoreController gameScoreController, ISetRulesController setRulesController, IMatchRulesController matchRulesController)
        {
            _gameScoreController = gameScoreController;
            _setRulesController = setRulesController;
            _matchRulesController = matchRulesController;
        }

        public IMatch CreateMatch(int numberOfSets)
        {
            return new Match(numberOfSets, _gameScoreController, _setRulesController, _matchRulesController);
        }
    }
}