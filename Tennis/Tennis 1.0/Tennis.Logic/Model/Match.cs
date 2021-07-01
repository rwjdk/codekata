using System;
using System.Collections.Generic;
using System.Linq;
using Tennis.Logic.Interface;

namespace Tennis.Logic.Model
{
    public class Match : IMatch
    {
        private readonly IMatchRulesController _matchRulesController;
        public Player? Winner { get; private set; }
        public List<ISet> Sets { get; }
        public int CurrentSetNumber { get; private set; }
        public IGame CurrentGame { get; }
        public Player CurrentServe { get; private set; }
        public ISet CurrentSet => Sets[CurrentSetNumber - 1];
        public Match(int numberOfSets, IGameRulesController gameRulesController, IGameScoreController gameScoreController, ISetRulesController setRulesController, IMatchRulesController matchRulesController)
        {
            if (numberOfSets != 1 && numberOfSets != 3 && numberOfSets != 5)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfSets), "Number of set need to be 1, 3 or 5");
            }
            _matchRulesController = matchRulesController;

            CurrentSetNumber = 1;

            CurrentGame = new Game(gameRulesController, gameScoreController);
            CurrentServe = Player.Player1;

            Sets = new List<ISet>();
            for (int i = 0; i < numberOfSets; i++)
            {
                Sets.Add(new Set(setRulesController));
            }
        }


        public void RegisterPoint(Player playerWhoWon)
        {
            CurrentGame.RegisterPoint(playerWhoWon);
            if (!CurrentGame.Winner.HasValue)
            {
                return;
            }

            //Game is over. Reset and RegisterGame in set
            CurrentGame.Reset();
            SwitchCurrentServe();
           
            CurrentSet.RegisterGame(playerWhoWon);


            if (!CurrentSet.Winner.HasValue)
            {
                return;
            }

            var player1Sets = GetSetsWonByPlayer(Player.Player1);
            var player2Sets = GetSetsWonByPlayer(Player.Player2);
            if (_matchRulesController.IsWinningScenario(Sets.Count, player1Sets, player2Sets))
            {
                Winner = playerWhoWon;
            }
            else
            {
                CurrentSetNumber++;
            }
        }

        private void SwitchCurrentServe()
        {
            CurrentServe = CurrentServe == Player.Player1 ? Player.Player2 : Player.Player1;
        }

        private int GetSetsWonByPlayer(Player player)
        {
            return Sets.Count(x => x.Winner == player);
        }
    }
}