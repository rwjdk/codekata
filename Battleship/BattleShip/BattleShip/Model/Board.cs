using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShip.Model
{
    public class Board
    {
        public int Width { get; private set; }
        public string Name { get; set; }
        public int Height { get; private set; }
        public List<Ship> Fleet { get; set; }
        public List<Coordinate> Misses { get; set; }
        public List<Coordinate> Hits { get; set; }

        public Board(string name, int height, int width, List<Ship> fleet)
        {
            Name = name;
            Height = height;
            Width = width;
            Misses = new List<Coordinate>();
            Hits = new List<Coordinate>();

            Fleet = fleet;
            foreach (var ship in fleet)
            {
                PlaceShip(ship);
            }
        }

        private void PlaceShip(Ship ship)
        {
            var random = new Random(DateTime.Now.Millisecond);
            var direction = (ShipDirection) random.Next(1, 3);
            int x;
            int y;
            switch (direction)
            {
                case ShipDirection.LeftRight:
                    x = random.Next(1, Width - ship.Length + 1);
                    y = random.Next(1, Height + 1);
                    for (int i = 0; i < ship.Length; i++)
                    {
                        var shipSection = ship.Sections[i];
                        shipSection.X = x;
                        shipSection.Y = y;
                        x++;
                    }
                    break;
                case ShipDirection.UpDown:
                    x = random.Next(1, Width + 1);
                    y = random.Next(1, Height - ship.Length + 1);
                    for (int i = 0; i < ship.Length; i++)
                    {
                        var shipSection = ship.Sections[i];
                        shipSection.X = x;
                        shipSection.Y = y;
                        y++;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (HasShipAllready(ship))
            {
                PlaceShip(ship);
            }
        }

        private bool HasShipAllready(Ship ship)
        {
            foreach (var conflictingShip in Fleet)
            {
                if (ship == conflictingShip)
                {
                    continue;
                }

                foreach (var section in conflictingShip.Sections)
                {
                    if (ship.Sections.Any(current => current.X == section.X && current.Y == section.Y))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public CoordinateResult GetResultFromCoordinate(int x, int y)
        {
            ShipSection resultSection = null;
            Ship resultShip = null;
            CoordinateResultType resultType = CoordinateResultType.Miss;
            foreach (var ship in Fleet)
            {
                foreach (var section in ship.Sections)
                {
                    if (section.X == x && section.Y == y)
                    {
                        resultType = CoordinateResultType.Hit;
                        resultShip = ship;
                        resultSection = section;
                    }
                }
            }

            return new CoordinateResult(resultSection, resultShip, resultType);
        }

        public bool HasMiss(int x, int y)
        {
            return Misses.Any(current => current.X == x && current.Y == y);
        }

        public bool HasHit(int x, int y)
        {
            return Hits.Any(current => current.X == x && current.Y == y);
        }

        public bool AllShipsSunk()
        {
            return Fleet.All(x => x.IsSunk());
        }

        public override string ToString()
        {
            return Name;
        }
    }
}