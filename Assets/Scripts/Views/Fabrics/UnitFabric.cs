using Models;
using Views.Units;

namespace Views.Fabrics
{
    public class UnitFabric
    {
        public Unit CreateUnitModel(UnitView unitView, Player player)
        {
            switch (unitView)
            {
                case ArcherView : return new Archer(player);
                case CatapultView: return new Catapult(player);
                case HorsemanView: return new Horseman(player);
                case SwordmanView: return new Swordsman(player);
            
                default: return null;
            };
        }
    }
}