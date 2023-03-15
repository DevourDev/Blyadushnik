namespace Game.Content.GameEntities.Characters.Stats
{
    public sealed class FloatingStatSo : StatSoBase<float>
    {
        protected override float ChangeValueInherited(float source, float delta)
        {
            return source + delta;
        }
    }
}
