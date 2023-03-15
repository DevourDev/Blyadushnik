namespace Game.Content.GameEntities.Characters.Stats
{
    public sealed class IntegerStatSo : StatSoBase<int>
    {
        protected override int ChangeValueInherited(int source, int delta)
        {
            return source + delta;
        }
    }
}
