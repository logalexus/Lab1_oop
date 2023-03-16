using System;

namespace Models
{
    public sealed class Archer : RangeUnit
    {
        public Archer(Player player) : base(player)
        {
            MaxHealth = 50;
            Health = MaxHealth;
            Damage = 50;

            _rangeMove = 3;
            _rangeAttack = 5;
        }
    }
}