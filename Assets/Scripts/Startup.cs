using Models;
using UnityEngine;
using Views;
using Views.Fabrics;
using Views.Units;

public class Startup : MonoBehaviour
{
    private GameController _gameController;
    private MapView _map;
    private UnitFabric _unitFabric;
    private Player _player;
        
    private void Start()
    {
        _unitFabric = new UnitFabric();

        CreateUnits();
    }

    private void CreateUnits()
    {
        foreach (var unitView in _map.Units)
        {
            Unit unit = _unitFabric.CreateUnitModel(unitView, _player);
            Vector3Int position = _map.WorldToCell(unitView.transform.position);
            unit.Position.Set(position.x, position.y);
            unitView.Init(unit);
        }
    }

    
}

