using Interfaces;

namespace Models
{
    public class Unit : GameObject, IUnit
    {
        public int Health { get; set; }
        
        public virtual void SetHealth(int value)
        {
            Health = value;
        }
    }
}