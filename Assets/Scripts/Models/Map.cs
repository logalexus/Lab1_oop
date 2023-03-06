using System.Collections.Generic;
using UnityEngine;
using Views;

namespace Models
{
    /// <summary>
    /// Карта.
    /// </summary>
    public sealed class Map
    {
        /// <inheritdoc />
        public Map(IReadOnlyList<Surface> ground, IReadOnlyList<Unit> units)
        {
            Ground = ground;
            Units = units;
        }


        /// <summary>
        /// Поверхность под ногами.
        /// </summary>
        public IReadOnlyList<Surface> Ground { get; }

        /// <summary>
        /// Список юнитов.
        /// </summary>
        public IReadOnlyList<Unit> Units { get; }
    }
}