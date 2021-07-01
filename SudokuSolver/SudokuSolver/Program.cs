using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver.Control;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var sudoku = new SudokuReader().Read("Sudokus\\Medium.txt");

            new Control.SudokuSolver().Solve(sudoku);

            foreach (var row in sudoku.Rows)
            {
                Console.WriteLine(row);    
            }

            Console.ReadKey();

        }
    }
}
