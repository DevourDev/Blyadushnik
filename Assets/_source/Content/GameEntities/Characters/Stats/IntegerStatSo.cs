using UnityEngine;

namespace Game.Content.GameEntities.Characters.Stats
{
    [CreateAssetMenu(menuName = GameAssetMenu.Characters + "Stats/Integer")]
    public sealed class IntegerStatSo : StatSoBase<int>
    {
        protected override int ChangeValueInherited(int source, int delta)
        {
            return source + delta;
        }
    }
}
