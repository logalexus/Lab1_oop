using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Views;
using Views.Surfaces;
using Views.Units;

namespace Gameplay
{
    public class SelectController
    {
        private MapView _mapView;
        private GameController _gameController;
        private List<SurfaceView> _moveArea;
        private List<UnitView> _enemies;
        private Player _currentPlayer;
        private UnitView _selectedUnit;

        public event Action<Unit, Surface> OnSelectSurfaceForMove;
        public event Action<Unit, Unit> OnSelectEnemyForAttack;
        
        public SelectController(MapView mapView, GameController gameController)
        {
            _mapView = mapView;
            _gameController = gameController;
            _moveArea = new List<SurfaceView>();
            _enemies = new List<UnitView>();
            
            foreach (var gameObjectView in _mapView.ObjectViews)
                gameObjectView.OnClicked += Select;
        }

        public void ChangeCurrentPlayer(Player player)
        {
            _currentPlayer = player;
        }
        
        private void Select(GameObjectView gameObjectView)
        {
            DeselectAll();

            if (gameObjectView is not UnitView unit)
                return;
            
            if(unit.PlayerID != _currentPlayer.Id || unit.Unit.Health <= 0)
                return;

            _selectedUnit = unit;
            
            ShowMoveArea(unit);
            ShowEnemies(unit);
        }

        private void DeselectAll()
        {
            HideMoveArea();
            HideEnemies();
        }

        private void ShowMoveArea(UnitView unitView)
        {
            _moveArea = _mapView.Surfaces.Where(cell =>
                _gameController.CanMoveUnit(
                    unitView.Unit,
                    cell.Surface.Position.X,
                    cell.Surface.Position.Y))
                .ToList();

            foreach (var surface in _moveArea)
            {
                surface.SetHighlight(true);
                surface.OnClicked += SelectSurfaceForMove;
            }
        }

        private void ShowEnemies(UnitView unitView)
        {
            _enemies = _mapView.Units.Where(enemy => 
                    enemy.PlayerID != _currentPlayer.Id && 
                    _gameController.CanAttackUnit(unitView.Unit, enemy.Unit))
                .ToList();

            foreach (var enemy in _enemies)
            {
                enemy.SetHighlight(true);
                enemy.OnClicked += SelectEnemyForAttack;
            }
        }

        private void SelectSurfaceForMove(GameObjectView gameObjectView)
        {
            SurfaceView surfaceView = gameObjectView as SurfaceView;
            OnSelectSurfaceForMove?.Invoke(_selectedUnit.Unit, surfaceView.Surface);
        }

        private void SelectEnemyForAttack(GameObjectView gameObjectView)
        {
            UnitView unitView = gameObjectView as UnitView;
            OnSelectEnemyForAttack?.Invoke(_selectedUnit.Unit, unitView.Unit);
        }

        private void HideMoveArea()
        {
            foreach (var surface in _moveArea)
            {
                surface.SetHighlight(false);
                surface.OnClicked -= SelectSurfaceForMove;
            }
        }

        private void HideEnemies()
        {
            foreach (var enemy in _enemies)
            {
                enemy.SetHighlight(false);
                enemy.OnClicked -= SelectEnemyForAttack;
            }
        }
    }
}