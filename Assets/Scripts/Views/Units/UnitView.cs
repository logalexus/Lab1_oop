using Models;

namespace Views.Units
{
    public class UnitView : GameObjectView, IUnit
    {
        private Unit _unit;
        
        public void Init(Unit unit)
        {
            _unit = unit;
        }
    }
}