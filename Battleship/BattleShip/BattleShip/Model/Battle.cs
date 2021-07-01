using System.Collections.Generic;

namespace BattleShip.Model
{
    internal class Battle
    {
        public Board Player1Board { get; private set; }
        public Board Player2Board { get; private set; }

        public Battle()
        {
            int height = 10;
            int width = 10;
            List<Ship> player1fleet = new List<Ship>()
            {
                Ship.GenerateShip(ShipType.Cruiser),
                Ship.GenerateShip(ShipType.Defender),
                Ship.GenerateShip(ShipType.Defender),
                Ship.GenerateShip(ShipType.Gunship),
                Ship.GenerateShip(ShipType.Patrole),
            };

            List<Ship> player2fleet = new List<Ship>()
            {
                Ship.GenerateShip(ShipType.Cruiser),
                Ship.GenerateShip(ShipType.Defender),
                Ship.GenerateShip(ShipType.Defender),
                Ship.GenerateShip(ShipType.Gunship),
                Ship.GenerateShip(ShipType.Patrole),
            };

            Player1Board = new Board("Player 1", height, width, player1fleet);
            Player2Board = new Board("Player 2", height, width, player2fleet);
        }
    }
}