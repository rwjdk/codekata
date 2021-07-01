using System;
using System.Collections.Generic;
using System.Linq;
using Logic.Interface;

namespace Logic.Controller
{
    public class GameIdGenerator : IGameIdGenerator
    {
        internal const int MaxValue = 999;
        private readonly Random _random;

        public GameIdGenerator()
        {
            _random = new Random();
        }
        
        public int GetUniqueGameId(List<int> usedGameIds)
        {
            bool uniqueGameIdNotFound = false;
            int randomGameId = _random.Next(1, MaxValue + 1); ;
            int tries = 0;
            while (!uniqueGameIdNotFound)
            {
                randomGameId = _random.Next(1, MaxValue+1);
                if (usedGameIds.All(x => x != randomGameId))
                {
                    uniqueGameIdNotFound = true;
                }

                tries++;
                if (tries == MaxValue)
                {
                    throw new ApplicationException();
                }
            }
            return randomGameId;            

        }
    }
}