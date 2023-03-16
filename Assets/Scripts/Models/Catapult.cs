using System;

namespace Models
{
    public sealed class Catapult : RangeUnit
    {
        public Catapult(Player player) : base(player)
        {
            MaxHealth = 75;
            Health = MaxHealth;
            Damage = 100;

            _rangeMove = 1;
            _rangeAttack = 10;
        }
    }
}