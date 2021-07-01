using System.Collections.Generic;

namespace SudokuSolver.Model
{
    public class Sudoku
    {

        public Cell[,] Cells { get; }
        public Section[,] Sections { get; }
        public Line[] Rows { get; }
        public Line[] Columns { get; }
        
        public Sudoku()
        {
            Sections = new Section[3, 3];
            Cells = new Cell[9, 9];
            Rows = new Line[9];
            Columns = new Line[9];

            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    Cells[x, y] = new Cell(0);
                }
            }

            for (int i = 0; i < 9; i++)
            {
                Columns[i] = new Line(Cells[0+i,0],Cells[0+i,1],Cells[0+i,2],Cells[0+i,3],Cells[0+i,4],Cells[0+i,5],Cells[0+i,6],Cells[0+i,7],Cells[0+i,8]);
                foreach (var cell in Columns[i].Cells)
                {
                    cell.Column = Columns[i];
                }
                
                Rows[i] = new Line(Cells[0,0+i],Cells[1,0+i],Cells[2,0+i],Cells[3,0+i],Cells[4,0+i],Cells[5,0+i],Cells[6,0+i],Cells[7,0+i],Cells[8,0+i]);
                foreach (var cell in Rows[i].Cells)
                {
                    cell.Row = Rows[i];
                }
            }

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    var topLeft = Cells[x*3, y*3];
                    var topMiddle = Cells[x*3 + 1, y*3];
                    var topRight = Cells[x*3 + 2, y*3];
                    var middleLeft = Cells[x*3, y*3 + 1];
                    var middleMiddle = Cells[x*3 + 1, y*3 + 1];
                    var middleRight = Cells[x*3 + 2, y*3 + 1];
                    var bottomLeft = Cells[x*3, y*3 + 2];
                    var bottomMiddle = Cells[x*3 + 1, y*3 + 2];
                    var bottomRight = Cells[x*3 + 2, y*3 + 2];
                    Sections[x, y] = new Section(topLeft, topMiddle, topRight, middleLeft, middleMiddle, middleRight, bottomLeft, bottomMiddle, bottomRight);

                    foreach (var cell in Sections[x,y].Cells)
                    {
                        cell.Section = Sections[x, y];
                    }
                }
            }
        }
    }
}