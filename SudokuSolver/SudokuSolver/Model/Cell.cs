using System.Collections.Generic;

namespace SudokuSolver.Model
{
    public class Cell
    {
        public Line Row { get; set; }
        public Line Column { get; set; }
        public Section Section { get; set; }

        public int Value { get; set; }

        public Cell(int value)
        {
            Value = value;
            PossibleValues = new List<int>();
        }

        public List<int> PossibleValues { get; }

        public override string ToString()
        {
            return Value.ToString();
        }

        public void AddPossibleValue(int possibleValue)
        {
            if (!PossibleValues.Contains(possibleValue))
            {
                PossibleValues.Add(possibleValue);
            }
        }

        public void RemovePossibleValue(int impossibleValue)
        {
            if (PossibleValues.Contains(impossibleValue))
            {
                PossibleValues.Remove(impossibleValue);
            }
        }

        public void UpdatePossibleValues(List<int> usedValues)
        {
            if (Value != 0)
            {
                return;
            }
            for (int possibleValue = 1; possibleValue <= 9; possibleValue++)
            {
                if (!usedValues.Contains(possibleValue))
                {
                    AddPossibleValue(possibleValue);
                }
                else
                {
                    RemovePossibleValue(possibleValue);
                }
            }
        }
    }
}