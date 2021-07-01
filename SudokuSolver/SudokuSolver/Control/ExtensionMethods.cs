using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Model;

namespace SudokuSolver.Control
{
    public static class ExtensionMethods
    {
        public static List<int> GetUsedValues(this Cell[] cells)
        {
            return cells.Where(x=> x.Value != 0).Select(x => x.Value).ToList();
        }

        public static List<int> GetUsedValues(this Cell[,] cells)
        {
            var usedValues = new List<int>();
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    var value = cells[i,j].Value;
                    if (value != 0)
                    {
                        usedValues.Add(value);
                    }
                }
            }
            return usedValues;
        }
    }
}