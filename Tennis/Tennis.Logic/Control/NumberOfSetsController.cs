using System.Collections.Generic;
using System.Linq;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace Tennis.Logic.Control
{
    public class NumberOfSetsController : INumberOfSetsController
    {
        private int _numberOfSets;

        public NumberOfSetsController()
        {
            ValidNumberOfSets = new List<int> { 1, 3, 5 };
        }

        public IReadOnlyList<int> ValidNumberOfSets { get; }
        
        public int NumberOfSets
        {
            get => _numberOfSets;
            set
            {
                if (!ValidNumberOfSets.Contains(value))
                {
                    throw new InvalidNumberOfSetsException($"Needs to be on of the following values: {string.Join(",", ValidNumberOfSets)}");
                }
                _numberOfSets = value;
            }
        }

        public bool IsNotDefined()
        {
            return NumberOfSets == 0;
        }
    }
}