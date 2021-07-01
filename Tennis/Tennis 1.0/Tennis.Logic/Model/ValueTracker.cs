using System;
using System.Collections.Generic;
using Tennis.Logic.Interface;

namespace Tennis.Logic.Model
{
    internal class ValueTracker : IValueTracker
    {
        private readonly Dictionary<Player, int> _values;

        public ValueTracker()
        {
            _values = new Dictionary<Player, int> { { Player.Player1, 0 }, { Player.Player2, 0 } };
        }

        public void Reset()
        {
            _values[Player.Player1] = 0;
            _values[Player.Player2] = 0;
        }

        public void TrackPoint(Player player)
        {
            if (!_values.ContainsKey(player))
            {
                throw new ArgumentOutOfRangeException(nameof(player));
            }
            _values[player]++;
        }

        public int GetPoint(Player player)
        {
            if (!_values.ContainsKey(player))
            {
                throw new ArgumentOutOfRangeException(nameof(player));
            }
            return _values[player];
        }
    }
}