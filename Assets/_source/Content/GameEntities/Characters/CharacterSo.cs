using DevourDev.Unity.MultiCulture;
using DevourDev.Unity.ScriptableObjects;
using UnityEngine;

namespace Game.Content.GameEntities.Characters
{
    [CreateAssetMenu(menuName = GameAssetMenu.Characters + "Character")]
    public sealed class CharacterSo : SoDatabaseElement
    {
        [SerializeField] private MultiCulturalText _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Sprite _preview;


        public MultiCulturalText CharacterName => _name;
        public Sprite Icon => _icon;
        public Sprite Preview => _preview;
    }

}
