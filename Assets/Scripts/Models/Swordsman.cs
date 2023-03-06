using System;

namespace Models
{
    /// <summary>
    /// Класс мечника.
    /// </summary>
    public sealed class Swordsman : Unit
    {
        public Swordsman(Player player) : base(player)
        {
            Health = 100;
            Damage = 50;
        }

        public override bool CanMoveInArea(int x, int y) =>
            Math.Abs(this.Position.X - x) <= 5 && Math.Abs(this.Position.Y - y) <= 5;
        
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