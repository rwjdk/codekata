using System.Collections.Generic;

namespace BattleShip.Model
{
    public class ShipSection
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Damaged { get; set; }

        public static List<ShipSection> GenerateSections(int length)
        {
            var result = new List<ShipSection>();
            for (int i = 0; i < length; i++)
            {
                result.Add(new ShipSection());
            }
            return result;
        }

        public override string ToString()
        {
            if (Damaged)
            {
                return string.Format("[{0},{1} (Damaged)]", X, Y);    
            }
            return string.Format("[{0},{1}]", X, Y);
        }
    }
}