using UnityEngine;

namespace Views
{
    public class GameObjectView : MonoBehaviour
    {
        public void SetPosition(int x, int y) =>
            transform.position = new Vector3(x, y, 0);

        public virtual Models.GameObject CreateModel() =>
            new Models.GameObject();
    }
}