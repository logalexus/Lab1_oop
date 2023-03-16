using System;
using UnityEngine;

namespace Models
{
    public abstract class Unit : GameObject
    {
        private int _health;
        protected int _rangeMove;
        public event Action<int> OnHealthChanged; 

        public Player Player { get; }

        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                _health = _health >= 0 ? _health : 0;
                OnHealthChanged?.Invoke(_health);
            }
        }
        
        public int Damage { get; protected set; }
        
        public int MaxHealth { get; protected set; }

        public bool IsDead => Health <= 0;

        public Unit(Player player)
        {
            Player = player;
        }
        
        public abstract bool CanMoveInArea(int x, int y);

        public virtual bool CanAttack(Unit otherUnit)
        {
            if (otherUnit.IsDead)
                return false;
            
            if (this.Player == otherUnit.Player)
                return false;

            return true;
        }

        public virtual void Attack(Unit other)
        {
            if (!this.CanAttack(other))
                return;
            
            other.Health -= Damage;
        }

    }
}