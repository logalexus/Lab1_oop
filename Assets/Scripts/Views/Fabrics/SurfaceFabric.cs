using Models;
using Views.Surfaces;

namespace Views.Fabrics
{
    public class SurfaceFabric
    {
        public Surface CreateSurfaceModel(SurfaceView surfaceView)
        {
            switch (surfaceView)
            {
                case WaterView : return new Water();
                case GrassView : return new Grass();
            
                default: return null;
            };
        }
    }
}