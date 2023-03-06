using System;

namespace Models
{
    /// <summary>
    /// Класс всадника.
    /// </summary>
    public sealed class Horseman : Unit
    {
        public Horseman(Player player) : base(player)
        {
            Health = 200;
            Damage = 75;
        }

        public override bool CanMoveInArea(int x, int y) =>
            Math.Abs(this.Position.X - x) <= 10 && Math.Abs(this.Position.Y - y) <= 10;

        public override bool CanAttack(Unit otherUnit)
        {
            if (!base.CanAttack(otherUnit))
                return false;
            
            var dx = Position.X - otherUnit.Position.X;
            var dy = Position.Y - otherUnit.Position.Y;

            return (dx == -1 || dx == 0 || dx == 1) &&
                   (dy == -1 || dy == 0 || dy == 1);
        }
    }
}