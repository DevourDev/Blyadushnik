namespace Game.Content.GameEntities.Characters.Stats
{
    public sealed class StatValue
    {
        private object _value;


        internal StatValue(object initialValue)
        {
            _value = initialValue;
        }

        internal T Read<T>()
        {
            return (T)_value;
        }

        internal void Write<T>(T v)
        {
            _value = v;
        }
    }
}
