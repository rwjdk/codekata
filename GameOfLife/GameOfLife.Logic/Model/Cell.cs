using System.Collections.Generic;
using GameOfLife.Logic.Extensions;

namespace GameOfLife.Logic.Model
{
    public class Cell
    {
        private int X { get; }
        private int Y { get; }
        private List<Coordinate> NeighborCoordinates { get; }
        public CellState State { get; }
        
        public Cell(int x, int y, CellState initialState)
        {
            X = x;
            Y = y;
            State = initialState;
            NeighborCoordinates = new List<Coordinate>
            {
                new Coordinate(x-1, y-1),
                new Coordinate(x-1, y),
                new Coordinate(x-1, y+1),
                new Coordinate(x, y-1),
                new Coordinate(x, y+1),
                new Coordinate(x+1, y-1),
                new Coordinate(x+1, y),
                new Coordinate(x+1, y+1),
            };
        }

        public Cell Tick(Cell[,] universe)
        {
            var numberOfNeighborsAlive = GetNumberOfNeighborsAlive(universe);

            if (State == CellState.Alive && (numberOfNeighborsAlive < 2 || numberOfNeighborsAlive > 3))
            {
                return new Cell(X, Y, CellState.Dead);
            }
            if (State == CellState.Alive && numberOfNeighborsAlive == 2 || numberOfNeighborsAlive == 3)
            {
                return new Cell(X, Y, CellState.Alive);
            }

            if (State == CellState.Dead && numberOfNeighborsAlive == 3)
            {
                return new Cell(X, Y, CellState.Alive);
            }

            return new Cell(X, Y, CellState.Dead);
        }

        private int GetNumberOfNeighborsAlive(Cell[,] universe)
        {
            int numberOfNeighborsAlive = 0;
            foreach (var neighborCoordinate in NeighborCoordinates)
            {
                var stateOfCoordinate = universe.GetState(neighborCoordinate);
                numberOfNeighborsAlive += stateOfCoordinate == CellState.Alive ? 1 : 0;
            }
            return numberOfNeighborsAlive;
        }

        public override string ToString()
        {
            return State.ToString();
        }
    }
}