using System;
using System.Linq;
using SudokuSolver.Model;

namespace SudokuSolver.Control
{
    public class SudokuSolver
    {
        public void Solve(Sudoku sudoku)
        {
            int iterations = 0;
            bool anyCellsResolved;
            do
            {
                Console.Clear();
                Console.WriteLine("iterations: "+iterations++);
                anyCellsResolved = false;
                foreach (var cell in sudoku.Cells)
                {
                    var usedValues = cell.Column.Cells.GetUsedValues();
                    usedValues.AddRange(cell.Row.Cells.GetUsedValues());
                    usedValues.AddRange(cell.Section.Cells.GetUsedValues());
                    usedValues = usedValues.Distinct().ToList();
                    if (usedValues.Count < 9)
                    {
                        cell.UpdatePossibleValues(usedValues);
                        if (cell.PossibleValues.Count == 1)
                        {
                            cell.Value = cell.PossibleValues.First();
                            anyCellsResolved = true;
                        }
                    }
                }    
            } while (anyCellsResolved);
        }
    }
}