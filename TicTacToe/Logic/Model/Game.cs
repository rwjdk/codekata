using JetBrains.Annotations;

namespace Logic.Model
{
    public class Game
    {
        [UsedImplicitly]
        public Player StartingPlayer { get; set; }

        public Player NextPlayer { get; set; }

        [UsedImplicitly]
        public int Id { get; set; }

        [UsedImplicitly]
        public Player[,] Board { get; set; }

        public Game(Player startingPlayer, Player nextPlayer, int id, Player[,] board)
        {
            StartingPlayer = startingPlayer;
            NextPlayer = nextPlayer;
            Id = id;
            Board = board;
        }

        public Player GetWinner()
        {
            if (IsPlayerWinning(Player.HostingPlayer))
            {
                return Player.HostingPlayer;
            }

            if (IsPlayerWinning(Player.JoiningPlayer))
            {
                return Player.JoiningPlayer;
            }

            return Player.None;
        }

        private bool IsPlayerWinning(Player playerToCheck)
        {
            for (int i = 0; i < 3; i++)
            {
                //Horizontal
                if (Board[i, 0] == playerToCheck && Board[i, 1] == playerToCheck && Board[i, 2] == playerToCheck)
                {
                    return true;
                }

                //Vertical
                if (Board[0, i] == playerToCheck && Board[1, i] == playerToCheck && Board[2, i] == playerToCheck)
                {
                    return true;
                }
            }
            
            //Cross 1
            if (Board[0, 0] == playerToCheck && Board[1, 1] == playerToCheck && Board[2, 2] == playerToCheck)
            {
                return true;
            }

            //Cross 2
            if (Board[2, 0] == playerToCheck && Board[1, 1] == playerToCheck && Board[0, 2] == playerToCheck)
            {
                return true;
            }

            return false;
        }

        internal bool NoMoreMovesLeft()
        {
            for (int row = 0; row < Board.GetLength(0); row++)
            {
                for (int column = 0; column < Board.GetLength(1); column++)
                {
                    if (Board[row, column] == Player.None)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        internal static Game CreateNewGame(Player startingPlayer, int gameId)
        {
            //Since new game starting player and next player are the same
            return new Game(startingPlayer, startingPlayer, gameId, new[,]
            {
                {Player.None, Player.None, Player.None },
                {Player.None, Player.None, Player.None },
                {Player.None, Player.None, Player.None }
            });
        }
    }
}