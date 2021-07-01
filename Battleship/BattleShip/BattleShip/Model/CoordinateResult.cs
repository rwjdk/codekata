namespace BattleShip.Model
{
    public class CoordinateResult
    {
        public Ship Ship { get; private set; }
        public ShipSection Section { get; private set; }
        public CoordinateResultType Type { get; private set; }

        public CoordinateResult(ShipSection section, Ship ship, CoordinateResultType type)
        {
            Section = section;
            Ship = ship;
            Type = type;
        }
    }
}