using System;
using System.IO;
using SudokuSolver.Model;

namespace SudokuSolver.Control
{
    public class SudokuReader
    {
        public Sudoku Read(string path)
        {
            var sudoku = new Sudoku();
            var rows = File.ReadAllLines(path);
            for (int y = 0; y < rows.Length; y++)
            {
                var row = rows[y];
                for (int x = 0; x < 9; x++)
                {
                    var value = row[x].ToString();
                    sudoku.Cells[x,y].Value = Convert.ToInt32(value);
                }
            }
            return sudoku;
        }
    }
}