using System.Collections.Generic;
using Gameplay;
using Models;
using UnityEngine;
using Views;
using Views.Fabrics;
using Views.Units;

public class Startup : MonoBehaviour
{
    [SerializeField] private PlayersConfig _playersConfig;
    [SerializeField] private MapView _mapView;
    
    private GameController _gameController;
    private SelectController _selectController;
    private PlayerMoveMachine _playerMoveMachine;
    private Map _map;
    private UnitFabric _unitFabric;
    private SurfaceFabric _surfaceFabric;
    private Player _player1;
    private Player _player2;
    private List<Unit> _units;
    private List<Surface> _surfaces;
    
    private void Start()
    {
        _mapView.Init();
        
        CreateUnits();
        CreateSurfaces();

        _player1 = new Player();
        _map = new Map(_surfaces, _units);
        _gameController = new GameController(_map);
        _selectController = new SelectController(_mapView, _gameController);
        _playerMoveMachine = new PlayerMoveMachine(_playersConfig, _selectController, _gameController);
    }

    private void CreateUnits()
    {
        _unitFabric = new UnitFabric();
        _units = new List<Unit>();
        
        
        foreach (var unitView in _mapView.Units)
        {
            Player player = _playersConfig.Players[unitView.PlayerID];
            Unit unit = _unitFabric.CreateUnitModel(unitView, player);
            Vector3Int position = _mapView.WorldToCell(unitView.transform.position);
            unit.Position.Set(position.x, position.y);
            unitView.Init(unit, _mapView);
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
            surfaceView.Init(surface);
            _surfaces.Add(surface);
        }
    }
}

