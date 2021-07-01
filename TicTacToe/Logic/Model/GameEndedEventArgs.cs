namespace Logic.Model
{
    public class GameEndedEventArgs
    {
        public PlayerViewModel Winner { get; }
        public string Result { get; }
        public string[,] FinalVisualBoard { get; }

        public GameEndedEventArgs(PlayerViewModel winner, string result, string[,] finalVisualBoard)
        {
            Winner = winner;
            Result = result;
            FinalVisualBoard = finalVisualBoard;
        }
    }
}