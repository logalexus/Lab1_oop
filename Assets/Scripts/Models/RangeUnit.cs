using System;

namespace Models
{
    public class RangeUnit : Unit
    {
        protected int _rangeAttack;
        
        public RangeUnit(Player player) : base(player)
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

            return dx >= -_rangeAttack && dx <= _rangeAttack && dy >= -_rangeAttack && dy <= _rangeAttack;
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