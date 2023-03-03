using System.Collections.Generic;
using Models;
using UnityEngine;
using Views.Units;

namespace Views
{
    public class MapView : MonoBehaviour
    {
        [SerializeField] private Grid _grid;
        [SerializeField] private List<Surface> _surfaces;
        [SerializeField] private List<UnitView> _units;

        public List<Surface> Surfaces => _surfaces;
        public List<UnitView> Units => _units;
        
        public Vector3 GetWorldCoordinates(Vector2Int point) =>
            _grid.CellToWorld((Vector3Int)point);
    }
}