namespace SudokuSolver.Model
{
    public class Line
    {
        public Cell[] Cells { get; }

        public Line(Cell c1, Cell c2, Cell c3, Cell c4, Cell c5, Cell c6, Cell c7, Cell c8, Cell c9)
        {
            Cells = new Cell[9];
            Cells[0] = c1;
            Cells[1] = c2;
            Cells[2] = c3;
            Cells[3] = c4;
            Cells[4] = c5;
            Cells[5] = c6;
            Cells[6] = c7;
            Cells[7] = c8;
            Cells[8] = c9;
        }

        public override string ToString()
        {
            return Cells[0].ToString() + Cells[1] + Cells[2] + Cells[3] + Cells[4] + Cells[5] + Cells[6] + Cells[7] + Cells[8];
        }
    }
}