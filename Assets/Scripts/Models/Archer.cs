using System;

namespace Models
{
    /// <summary>
    /// Лучник.
    /// </summary>
    public sealed class Archer : Unit
    {
        /// <inheritdoc />
        public Archer(Player player) : base(player)
        {
            Health = 50;
            Damage = 50;
        }

        public override bool CanMoveInArea(int x, int y) =>
            Math.Abs(this.Position.X - x) <= 3 && Math.Abs(this.Position.Y - y) <= 3;
        
        public override bool CanAttack(Unit otherUnit)
        {
            if (!base.CanAttack(otherUnit))
                return false;
            
            var dx = Position.X - otherUnit.Position.X;
            var dy = Position.Y - otherUnit.Position.Y;

            return dx >= -5 && dx <= 5 && dy >= -5 && dy <= 5;
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