namespace Logic.Model
{
    public class PlayerViewModel
    {
        public Player Player { get; }
        public string Symbol { get; }

        public PlayerViewModel(Player player, Player startingPlayer)
        {
            Player = player;
            Symbol = startingPlayer == player ? "X" : "O";
        }
    }
}