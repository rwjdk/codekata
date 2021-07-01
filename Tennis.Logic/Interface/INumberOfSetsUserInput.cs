using Tennis.Logic.Model;

namespace Tennis.Logic.Interface
{
    public interface INumberOfSetsUserInput
    {
        NumberOfSetsUserInput Input { get; }
        int InputAsInteger { get; }
    }
}