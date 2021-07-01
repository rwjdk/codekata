namespace SudokuSolver.Model
{
    public class Section
    {
        public Cell[,] Cells { get; }

        public Section(Cell topLeft, Cell topMiddle, Cell topRight, Cell middleLeft, Cell middleMiddle, Cell middleRight, Cell bottomLeft, Cell bottomMiddle, Cell bottomRight)
        {
            Cells = new Cell[3, 3];
            Cells[0, 0] = topLeft;
            Cells[1, 0] = topMiddle;
            Cells[2, 0] = topRight;
            Cells[0, 1] = middleLeft;
            Cells[1, 1] = middleMiddle;
            Cells[2, 1] = middleRight;
            Cells[0, 2] = bottomLeft;
            Cells[1, 2] = bottomMiddle;
            Cells[2, 2] = bottomRight;
        }
    }
}