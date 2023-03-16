namespace Models
{
    public sealed class Horseman : MeleeUnit
    {
        public Horseman(Player player) : base(player)
        {
            MaxHealth = 200;
            Health = MaxHealth;
            Damage = 75;

            _rangeMove = 10;
        }
    }
}