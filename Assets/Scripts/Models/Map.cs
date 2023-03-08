using System.Collections.Generic;
using UnityEngine;
using Views;

namespace Models
{
    public sealed class Map
    {
        public Map(IReadOnlyList<Surface> ground, IReadOnlyList<Unit> units)
        {
            Ground = ground;
            Units = units;
        }

        public IReadOnlyList<Surface> Ground { get; }

        public IReadOnlyList<Unit> Units { get; }
    }
}