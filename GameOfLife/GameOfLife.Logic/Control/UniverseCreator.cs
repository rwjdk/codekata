using System;
using GameOfLife.Logic.Model;

namespace GameOfLife.Logic.Control
{
    public class UniverseCreator
    {
        public Cell[,] CreateConsoleUniverse(string[] seedLines)
        {
            if (seedLines == null)
            {
                throw new ArgumentNullException(nameof(seedLines));
            }

            if (seedLines.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(seedLines), "Need at least one line");
            }

            var width = seedLines[0].Length;
            Cell[,] universe = new Cell[width,seedLines.Length];

            int x = 0;
            int y = 0;
            foreach (var seedLine in seedLines)
            {
                foreach (var cellValue in seedLine)
                {
                    universe[x,y] = new Cell(x, y, cellValue == Constants.SeedAliveCellRepresenation ? CellState.Alive : CellState.Dead);
                    x++;
                }
                y++;
                x = 0;
            }
            return universe;
        }
    }
}