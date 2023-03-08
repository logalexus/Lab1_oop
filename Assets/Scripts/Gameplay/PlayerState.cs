using Models;
using UnityEngine;

namespace Gameplay
{
    public class PlayerState
    {
        private PlayerMoveMachine _playerMoveMachine;
        private Player _player;
        private SelectController _selectController;
        private GameController _gameController;

        public PlayerState(PlayerMoveMachine playerMoveMachine, Player player, SelectController selectController,
            GameController gameController)
        {
            _playerMoveMachine = playerMoveMachine;
            _player = player;
            _selectController = selectController;
            _gameController = gameController;
        }

        public void Enter()
        {
            _selectController.ChangeCurrentPlayer(_player);
            _selectController.OnSelectEnemyForAttack += AttackUnit;
            _selectController.OnSelectSurfaceForMove += MoveUnit;
            
            Debug.Log($"Enter {_player.Name}");
        }

        private void MoveUnit(Unit unit, Surface surface)
        {
            _gameController.MoveUnit(unit, surface);
            Debug.Log($"Move {_player.Name}");
            _playerMoveMachine.NextState();
        }

        private void AttackUnit(Unit unit, Unit target)
        {
            _gameController.AttackUnit(unit, target);
            _playerMoveMachine.NextState();
        }

        public void Exit()
        {
            _selectController.OnSelectEnemyForAttack -= AttackUnit;
            _selectController.OnSelectSurfaceForMove -= MoveUnit;
            Debug.Log($"Exit {_player.Name}");
        }
    }
}