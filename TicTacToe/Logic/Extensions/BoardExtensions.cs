using Logic.Model;

namespace Logic.Extensions
{
    public static class BoardExtensions
    {
        public static string[,] GetVisualBoard(this Player[,] board, PlayerViewModel me, PlayerViewModel opponent)
        {
            var result = new[,]
            {
                { string.Empty, string.Empty, string.Empty },
                { string.Empty, string.Empty, string.Empty },
                { string.Empty, string.Empty, string.Empty }
            };

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    Player player = board[row, column];
                    string symbol;
                    if (player == Player.None)
                    {
                        symbol = string.Empty;
                    }
                    else if (player == me.Player)
                    {
                        symbol = me.Symbol;
                    }
                    else
                    {
                        symbol = opponent.Symbol;
                    }

                    result[row, column] = symbol;
                }
            }

            return result;
        }
    }
}