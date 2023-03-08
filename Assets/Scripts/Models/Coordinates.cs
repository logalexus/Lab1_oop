using System;

namespace Models
{
    public sealed class Coordinates
    {
        public event Action<Coordinates> OnValueChanged;
        
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; } 

        public int Y { get; private set; }

        public void Set(int x, int y)
        {
            X = x;
            Y = y;
            
            OnValueChanged?.Invoke(this);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Coordinates other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        private bool Equals(Coordinates other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}