using System;

namespace Models
{
    public sealed class Swordsman : MeleeUnit
    {
        public Swordsman(Player player) : base(player)
        {
            MaxHealth = 100;
            Health = MaxHealth;
            Damage = 50;

            _rangeMove = 5;
        }
    }
}