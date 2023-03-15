using Game.Content.GameEntities.Characters.Emotions;
using UnityEngine;

namespace Game.Content.GameEntities.Characters
{
    public sealed class CharacterOnScene : MonoBehaviour
    {
        [SerializeField] private CharacterSo _reference;

        private EmotionSo _emotion;


        public CharacterSo Reference => _reference;

        public EmotionSo Emotion
        {
            get => _emotion;
            set => SetEmotion(value);
        }

        private void SetEmotion(EmotionSo value)
        {
            if (_emotion == value)
                return;

            _emotion = value;
            Debug.Log($"Character {_reference.CharacterName.Get()} switched emotion to {_emotion}");
        }
    }
}
