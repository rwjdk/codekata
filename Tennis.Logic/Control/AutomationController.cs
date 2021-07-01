using System;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace Tennis.Logic.Control
{
    public class AutomationController : IAutomationController
    {
        private readonly Random _random;

        public AutomationController()
        {
            _random = new Random(DateTime.Now.Millisecond);
        }

        public Player GetRandomPlayer()
        {
            var next = _random.Next(1, 3);
            return (Player)next;
        }
    }
}