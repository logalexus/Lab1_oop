using UnityEngine;

namespace Views
{
    public class GameView : MonoBehaviour
    {
        public void SetPosition(int x, int y) =>
            transform.position = new Vector3(x, y, 0);
        
        
    }
}