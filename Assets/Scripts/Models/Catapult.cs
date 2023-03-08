using System;

namespace Models
{
    public sealed class Catapult : Unit
    {
        public Catapult(Player player) : base(player)
        {
            MaxHealth = 75;
            Health = MaxHealth;
            Damage = 100;
        }

        public override bool CanMoveInArea(int x, int y) =>
            Math.Abs(this.Position.X - x) <= 1 && Math.Abs(this.Position.Y - y) <= 1;

        public override bool CanAttack(Unit otherUnit)
        {
            if (!base.CanAttack(otherUnit))
                return false;

            var dx = Position.X - otherUnit.Position.X;
            var dy = Position.Y - otherUnit.Position.Y;

            return dx >= -10 && dx <= 10 && dy >= -10 && dy <= 10;
        }

        public override void Attack(Unit other)
        {
            if (!this.CanAttack(other))
                return;

            int damage = Damage;
            
            var dx = this.Position.X - other.Position.X;
            var dy = this.Position.Y - other.Position.Y;

            if ((dx == -1 || dx == 0 || dx == 1) &&
                (dy == -1 || dy == 0 || dy == 1))
            {
                damage /= 2;
            }

            other.Health -= damage;
        }
    }
}