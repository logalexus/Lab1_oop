using Models;
using UnityEngine;
using GameObject = UnityEngine.GameObject;

namespace Views.Surfaces
{
    public class SurfaceView : GameObjectView
    {
        [SerializeField] private SpriteRenderer _highlight;
        
        protected Surface _surface;
        
        public Surface Surface => _surface;

        public void Init(Surface surface)
        {
            _surface = surface;
        }

        public void SetHighlight(bool value)
        {
            _highlight.gameObject.SetActive(value);
        }
    }
}