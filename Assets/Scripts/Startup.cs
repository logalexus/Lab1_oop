using System.Collections.Generic;
using Models;
using UnityEngine;
using Views;
using Views.Fabrics;
using Views.Units;

public class Startup : MonoBehaviour
{
    private GameController _gameController;
    private MapView _mapView;
    private Map _map;
    private UnitFabric _unitFabric;
    private SurfaceFabric _surfaceFabric;
    private Player _player;
    private List<Unit> _units;
    private List<Surface> _surfaces;
    
    private void Start()
    {
        CreateUnits();
        CreateSurfaces();

        _map = new Map(_surfaces, _units);
        _gameController = new GameController(_map);
    }

    private void CreateUnits()
    {
        _unitFabric = new UnitFabric();
        _units = new List<Unit>();
        
        
        foreach (var unitView in _mapView.Units)
        {
            Unit unit = _unitFabric.CreateUnitModel(unitView, _player);
            Vector3Int position = _mapView.WorldToCell(unitView.transform.position);
            unit.Position.Set(position.x, position.y);
            unitView.Init(unit);
            _units.Add(unit);
        }
    }

    private void CreateSurfaces()
    {
        _surfaceFabric = new SurfaceFabric();
        _surfaces = new List<Surface>();
        
        foreach (var surfaceView in _mapView.Surfaces)
        {
            Surface surface = _surfaceFabric.CreateSurfaceModel(surfaceView);
            Vector3Int position = _mapView.WorldToCell(surfaceView.transform.position);
            surface.Position.Set(position.x, position.y);
            _surfaces.Add(surface);
        }
    }
}

