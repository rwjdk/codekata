using System;
using Logic.Interface;
using Logic.Model;

namespace Logic.Controller
{
    public class StartingPlayerController : IStartingPlayerController
    {
        private readonly Random _random;

        public StartingPlayerController()
        {
            _random = new Random();
        }

        public Player GetRandomStartingPlayer()
        {
            return (Player)_random.Next(1, 3); //3 as it is upper exclusive
        }
    }
}