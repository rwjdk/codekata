namespace Logic.Model
{
    public class NextPlayersTurnEventArgs
    {
        public PlayerViewModel NextPlayer { get; }
        public string[,] CurrentVisualBoard { get; }

        public NextPlayersTurnEventArgs(PlayerViewModel nextPlayer, string[,] currentVisualBoard)
        {
            NextPlayer = nextPlayer;
            CurrentVisualBoard = currentVisualBoard;
        }
    }
}