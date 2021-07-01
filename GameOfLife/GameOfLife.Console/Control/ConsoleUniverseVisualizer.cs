using GameOfLife.Logic.Model;

namespace GameOfLife.Console.Control
{
    public class ConsoleUniverseVisualizer
    {
        public void WriteUniverse(Cell[,] universe)
        {
            var width = universe.GetLength(0);
            var height = universe.GetLength(1);
            int x = 0;
            int y = 0;
            while (y < height)
            {
                while (x < width)
                {
                    System.Console.Write(universe[x,y].State == CellState.Alive ? "*" : " ");
                    x++;
                }
                System.Console.WriteLine();
                y++;
                x = 0;
            }
        }
    }
}