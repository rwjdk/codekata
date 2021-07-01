using System.Collections.Generic;
using Logic.Interface;

namespace Tests.Fakes
{
    public class FakeGameIdController : IGameIdGenerator
    {
        public int GetUniqueGameId(List<int> usedGameIds)
        {
            return 1234;
        }
    }
}