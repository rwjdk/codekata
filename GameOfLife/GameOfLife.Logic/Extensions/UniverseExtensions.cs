using GameOfLife.Logic.Model;

namespace GameOfLife.Logic.Extensions
{
    public static class UniverseExtensions
    {
        public static CellState GetState(this Cell[,] universe, Coordinate coordinate)
        {
            if (coordinate.X < 0 || coordinate.Y < 0 || coordinate.X >= universe.GetLength(0) || coordinate.Y >= universe.GetLength(1))
            {
                //Outside known universe (Always dead)
                return CellState.Dead;
            }
            return universe[coordinate.X, coordinate.Y].State;
        }

        public static Cell[,] Tick(this Cell[,] universe)
        {
            var width = universe.GetLength(0);
            var height = universe.GetLength(1);
            Cell[,] newStateOfUniverse = new Cell[width,height];

            int x = 0;
            int y = 0;
            while (y < height)
            {
                while (x < width)
                {
                    var oldCell = universe[x, y];
                    var newstateOfCell = oldCell.Tick(universe);
                    newStateOfUniverse[x, y] = newstateOfCell;
                    x++;
                }
                y++;
                x = 0;
            }

            return newStateOfUniverse;
        }
    }
}