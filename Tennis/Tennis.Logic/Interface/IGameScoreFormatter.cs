using Tennis.Logic.Model;

namespace Tennis.Logic.Interface
{
    public interface IGameScoreFormatter
    {
        string FormatPoint(GameScoreEnum? gameScore);

    }
}