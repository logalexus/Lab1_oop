using System;
using UnityEngine;
using Views.Units;

namespace Views
{
    public class GameObjectView : MonoBehaviour
    {
        public event Action<GameObjectView> OnClicked;
        
        private void OnMouseDown()
        {
            OnClicked?.Invoke(this);
        }
    }
}