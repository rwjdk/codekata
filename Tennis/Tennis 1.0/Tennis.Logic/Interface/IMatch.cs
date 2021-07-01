using System.Collections.Generic;
using Tennis.Logic.Model;

namespace Tennis.Logic.Interface
{
    public interface IMatch
    {
        Player? Winner { get; }
        List<ISet> Sets { get; }
        int CurrentSetNumber { get; }
        IGame CurrentGame { get; }
        ISet CurrentSet { get; }
        Player CurrentServe { get; }
        void RegisterPoint(Player playerWhoWon);
    }
}