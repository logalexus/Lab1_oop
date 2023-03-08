using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;
using Views.Surfaces;
using Views.Units;

namespace Views
{
    public class MapView : MonoBehaviour
    {
        [SerializeField] private Grid _grid;
        [SerializeField] private List<GameObjectView> _objectViews;
        
        public List<SurfaceView> Surfaces { get; private set; }
        public List<UnitView> Units { get; private set;}

        public List<GameObjectView> ObjectViews => _objectViews;
        
        public Vector3 CellToWorld(Vector2Int point) =>
            _grid.CellToWorld((Vector3Int)point);
        
        public Vector3Int WorldToCell(Vector3 position) =>
            _grid.WorldToCell(position);

        public void Init()
        {
            Surfaces = _objectViews.OfType<SurfaceView>().ToList();
            Units = _objectViews.OfType<UnitView>().ToList();
        }

        [Button]
        public void Fill()
        {
            _objectViews.Clear();
            _objectViews.AddRange(FindObjectsOfType<GameObjectView>());
        }
    }
}