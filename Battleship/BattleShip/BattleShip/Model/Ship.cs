using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleShip.Model
{
    public class Ship
    {
        public string Name { get; private set; }
        public List<ShipSection> Sections { get; private set; }

        public int Length
        {
            get { return Sections.Count; }
        }

        public string Symbol
        {
            get { return Name[0].ToString(); }
        }


        public bool IsSunk()
        {
            return Sections.All(x => x.Damaged);
        }

        public Ship(string name, List<ShipSection> sections)
        {
            Name = name;
            Sections = sections;
        }

        public static Ship GenerateShip(ShipType shipType)
        {
            int length = (int) shipType;
            switch (shipType)
            {
                case ShipType.Cruiser:
                    return new Ship("Cruiser", ShipSection.GenerateSections(length));
                case ShipType.Defender:
                    return new Ship("Defender", ShipSection.GenerateSections(length));
                case ShipType.Gunship:
                    return new Ship("Gunship", ShipSection.GenerateSections(length));
                case ShipType.Patrole:
                    return new Ship("Patrole", ShipSection.GenerateSections(length));
                default:
                    throw new ArgumentOutOfRangeException("shipType");
            }
        }

        public override string ToString()
        {
            var sectionString = new StringBuilder();
            foreach (var section in Sections)
            {
                sectionString.Append(section);
            }

            return string.Format("{0} - {1}", Name, sectionString);
        }
    }
}