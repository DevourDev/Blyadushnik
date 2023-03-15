using System.Collections.Generic;
using UnityEngine;

namespace Game.Content.GameEntities.Characters.Stats
{
    public abstract class StatsCollectionBase<T> : MonoBehaviour
    {
        private readonly Dictionary<StatSoBase<T>, StatValue> _stats = new();


        public System.Type StatValueType => typeof(T);

        /// <summary>
        /// stat, newValue, rawDelta
        /// </summary>
        public event System.Action<StatSoBase<T>, T, T> OnStatValueChanged;


        public T GetStatValue(StatSoBase<T> stat)
        {
            var sv = GetStatValueInternal(stat);
            var value = sv == null ? stat.DefaultValue : stat.GetValue(sv);
            return value;
        }

        public void SetStatValue(StatSoBase<T> stat, T newValue)
        {
            var sv = GetOrCreateStatValueInternal(stat);
            stat.SetValue(sv, newValue);

            OnStatValueChanged?.Invoke(stat, newValue, default!);
        }

        public void ChangeStatValue(StatSoBase<T> stat, T delta)
        {
            var sv = GetOrCreateStatValueInternal(stat);
            var newV = stat.ChangeValue(sv, delta);

            OnStatValueChanged?.Invoke(stat, newV, delta);
        }

        private StatValue GetStatValueInternal(StatSoBase<T> stat)
        {
            _ = _stats.TryGetValue(stat, out var statValue);
            return statValue;
        }

        private StatValue GetOrCreateStatValueInternal(StatSoBase<T> stat)
        {
            if (!_stats.TryGetValue(stat, out var statValue))
            {
                statValue = new StatValue(stat.DefaultValue);
                _stats.Add(stat, statValue);
            }

            return statValue;
        }
    }
}
