using Game.Content.GameEntities.Characters.Stats;
using UnityEngine;

namespace Game.Core
{
    public sealed class Player : MonoBehaviour
    {
        [SerializeField] private IntStatsCollection _intStats;


        private static Player _inst;


        public static IntStatsCollection IntStats => _inst._intStats;


        private void Awake()
        {
            _inst = this;
        }

        private void OnDestroy()
        {
            if(_inst == this)
            {
                _inst = null;
            }
        }
    }
}
