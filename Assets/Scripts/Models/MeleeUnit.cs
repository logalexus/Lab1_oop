using System;

namespace Models
{
    public class MeleeUnit : Unit
    {
        public MeleeUnit(Player player) : base(player)
        {
        }

        public override bool CanMoveInArea(int x, int y) =>
            Math.Abs(this.Position.X - x) <= _rangeMove && Math.Abs(this.Position.Y - y) <= _rangeMove;

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