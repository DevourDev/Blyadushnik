using DevourDev.Unity.Utils;
using Game.Content.GameEntities.Characters.Stats;
using Game.Core;
using UnityEngine;

namespace Game.Ui
{
    public sealed class StatsView : MonoBehaviour
    {
        [SerializeField] private PoppingText3D _poppingTextPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Vector3 _direction = Vector3.up;
        [SerializeField] private string _statIncreasedMsg = "плюс стат";
        [SerializeField] private string _statDecreasedMsg = "минус стат";


        private void Start()
        {
            Player.IntStats.OnStatValueChanged += IntStats_OnStatValueChanged;
        }

        private void IntStats_OnStatValueChanged(StatSoBase<int> stat, int value, int delta)
        {
            var inst = Instantiate(_poppingTextPrefab);
            inst.transform.position = _spawnPoint.position;
            string msg = delta < 0 ? _statDecreasedMsg : _statIncreasedMsg;
            inst.SetText($"{msg} {stat.StatName.Get()}: {delta.ToString()}");
            inst.Direction = _direction;

            var sr = inst.GetComponentInChildren<SpriteRenderer>();

            if(sr != null)
            {
                sr.sprite = stat.Icon;
            }
        }
    }
}