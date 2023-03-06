using System.Collections.Generic;
using Models;
using UnityEngine;
using Views.Surfaces;
using Views.Units;

namespace Views
{
    public class MapView : MonoBehaviour
    {
        [SerializeField] private Grid _grid;
        [SerializeField] private List<SurfaceView> _surfaces;
        [SerializeField] private List<UnitView> _units;

        public List<SurfaceView> Surfaces => _surfaces;
        public List<UnitView> Units => _units;
        
        public Vector3 CellToWorld(Vector2Int point) =>
            _grid.CellToWorld((Vector3Int)point);
        
        public Vector3Int WorldToCell(Vector3 position) =>
            _grid.WorldToCell(position);
        
    }
}