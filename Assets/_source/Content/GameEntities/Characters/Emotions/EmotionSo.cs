using DevourDev.Unity.MultiCulture;
using UnityEngine;

namespace Game.Content.GameEntities.Characters.Emotions
{
    [CreateAssetMenu(menuName = GameAssetMenu.Characters + "Emotion")]
    public sealed class EmotionSo : ScriptableObject //todo: make SoDatabaseElement
    {
        [SerializeField] private MultiCulturalText _name;


        public MultiCulturalText EmotionName => _name;
    }
}
