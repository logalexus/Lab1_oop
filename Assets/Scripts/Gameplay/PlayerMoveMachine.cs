using System.Collections.Generic;
using System.Linq;

namespace Gameplay
{
    public class PlayerMoveMachine
    {
        private PlayersConfig _playersConfig;
        private SelectController _selectController;
        private GameController _gameController;
        private List<PlayerState> _states;
        private PlayerState _currentState;
        private int _stateIndex = 0;
        private int _statesCount;

        public PlayerMoveMachine(PlayersConfig playersConfig, SelectController selectController,
            GameController gameController)
        {
            _playersConfig = playersConfig;
            _selectController = selectController;
            _gameController = gameController;

            CreateStates();

            _currentState = _states.First();
            _currentState.Enter();
        }

        private void CreateStates()
        {
            _states = new List<PlayerState>();
            _statesCount = _playersConfig.Players.Count;

            foreach (var player in _playersConfig.Players)
                _states.Add(new PlayerState(this, player, _selectController, _gameController));
        }


        public void NextState()
        {
            _currentState?.Exit();
            _currentState = _states[++_stateIndex % _statesCount];
            _currentState.Enter();
        }
    }
}