using Tennis.Logic.Model;

namespace Tennis.Logic.Interface
{
    internal interface IValueTracker
    {
        void Reset();
        void TrackPoint(Player player);
        int GetPoint(Player player);
    }
}