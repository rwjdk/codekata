namespace Tennis.Logic.Interface
{
    public interface IMatchController
    {
        IMatch CreateMatch(int numberOfSets);
    }
}