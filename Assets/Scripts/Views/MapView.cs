using UnityEngine;

namespace Views
{
    public class MapView : MonoBehaviour
    {
        [SerializeField] private Grid _grid;

        public Vector3 GetWorldCoordinates(Vector2Int point) =>
            _grid.CellToWorld((Vector3Int)point);
        
        
    }
}