using System.Collections.Generic;

namespace Logic.Interface
{
    public interface IGameIdGenerator
    {
        int GetUniqueGameId(List<int> usedGameIds);
    }
}