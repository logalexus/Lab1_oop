using System.Collections.Generic;
using System.Linq;
using Models;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    [CreateAssetMenu(menuName = "SO/" + nameof(PlayersConfig), fileName = nameof(PlayersConfig))]
    public class PlayersConfig : ScriptableObject
    {
        public List<Player> Players;
    }
}