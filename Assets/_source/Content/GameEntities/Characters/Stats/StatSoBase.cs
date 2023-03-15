using System;
using DevourDev.Unity.MultiCulture;
using DevourDev.Unity.ScriptableObjects;
using UnityEngine;

namespace Game.Content.GameEntities.Characters.Stats
{
    public abstract class StatSoBase : SoDatabaseElement
    {
        [SerializeField] private MultiCulturalText _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Sprite _preview;


        public MultiCulturalText StatName => _name;
        public Sprite Icon => _icon;
        public Sprite Preview => _preview;


        public abstract Type StatValueType { get; }


        internal abstract object GetValueAsObject(StatValue statValue);

        internal abstract void SetValueAsObject(StatValue statValue, object value);

        /// <returns>new value</returns>
        internal abstract object ChangeValueAsObject(StatValue statValue, object delta);
    }


    public abstract class StatSoBase<TValue> : StatSoBase
    {
        [SerializeField] private TValue _minValue;
        [SerializeField] private TValue _maxValue;
        [SerializeField] private TValue _defaultValue;
           

        public TValue MinValue => _minValue;
        public TValue MaxValue => _maxValue;
        public TValue DefaultValue => _defaultValue;


        public sealed override Type StatValueType => typeof(TValue);


        internal sealed override object GetValueAsObject(StatValue statValue)
        {
            return GetValue(statValue);
        }

        internal sealed override void SetValueAsObject(StatValue statValue, object value)
        {
            SetValue(statValue, (TValue)value);
        }

        internal sealed override object ChangeValueAsObject(StatValue statValue, object delta)
        {
            return ChangeValue(statValue, (TValue)delta);
        }


        internal TValue GetValue(StatValue statValue)
        {
            return statValue.Read<TValue>();
        }

        internal void SetValue(StatValue statValue, TValue value)
        {
            statValue.Write(value);
        }

        internal TValue ChangeValue(StatValue statValue, TValue delta)
        {
            var v = ChangeValueInherited(statValue.Read<TValue>(), delta);
            statValue.Write(v);
            return v;
        }


        protected abstract TValue ChangeValueInherited(TValue source, TValue delta);
    }
}
