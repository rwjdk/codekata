using System.Collections.Generic;

namespace Tennis.Logic.Interface
{
    public interface INumberOfSetsController
    {
        int NumberOfSets { get; set; }
        bool IsNotDefined();
        IReadOnlyList<int> ValidNumberOfSets { get; }
    }
}