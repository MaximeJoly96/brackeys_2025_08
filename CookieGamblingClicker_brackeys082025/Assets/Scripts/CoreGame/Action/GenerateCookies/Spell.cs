using System;

namespace CookieGambler
{
    /// <summary>
    /// This class represent the spell to summon cookies
    /// </summary>
    public class Spell
    {
        private readonly int MAX_BOUNDS = 10;
        private readonly int MIN_BOUNDS = 1;

        private int _maxBounds;
        private int _minBounds;

        private Random _rand;

        public Spell()
        {
            _maxBounds = MAX_BOUNDS;
            _minBounds = MIN_BOUNDS;
            _rand = new Random();
        }

        public void UpdateMinBounds(int minBounds)
        {
            _minBounds = minBounds;
        }

        public void UpdateMaxBounds(int maxBounds)
        {
            _maxBounds = maxBounds;
        }

        public int CastCookieSpell()
        {
            return _rand.Next(_minBounds, _maxBounds);
        }
    }
}
