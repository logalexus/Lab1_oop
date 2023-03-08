using Models;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Views.Units
{
    public class UnitView : GameObjectView
    {
        [SerializeField] private int _playerID;
        [SerializeField] private SpriteRenderer _highlight;
        [SerializeField] private SpriteRenderer _tambstone;
        [SerializeField] private SpriteRenderer _unitSprite;
        [SerializeField] private Slider healthBar;

        private Unit _unit;
        private MapView _mapView;

        public Unit Unit => _unit;
        public int PlayerID => _playerID;

        public void Init(Unit unit, MapView mapView)
        {
            _unit = unit;
            _mapView = mapView;
            _unit.Position.OnValueChanged += ChangePosition;
            _unit.OnHealthChanged += HealthChanged;

            healthBar.maxValue = _unit.MaxHealth;

            HealthChanged(_unit.Health);
        }

        private void HealthChanged(int value)
        {
            DOTween.To(() => healthBar.value, x => healthBar.value = x, value, 1);

            if (_unit.Health <= 0)
            {
                _unitSprite.enabled = false;
                _tambstone.gameObject.SetActive(true);
            }
        }

        private void ChangePosition(Coordinates position)
        {
            Vector3 targetPosition = _mapView.CellToWorld(new Vector2Int(position.X, position.Y));
            transform.position = targetPosition;
        }

        public void SetHighlight(bool value)
        {
            _highlight.gameObject.SetActive(value);
        }
    }
}