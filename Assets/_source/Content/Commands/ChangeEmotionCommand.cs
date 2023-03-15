using Game.Content.GameEntities.Characters;
using Game.Content.GameEntities.Characters.Emotions;
using Game.Core.CommandsSystem;
using UnityEngine;

namespace Game.Content.Commands
{


    [CreateAssetMenu(menuName = GameAssetMenu.Commands + "Change Emotion")]
    public sealed class ChangeEmotionCommand : CommandSo
    {
        [SerializeField] private CharacterSo _character;
        [SerializeField] private EmotionSo _emotion;


        public CharacterSo Character { get => _character; internal set => _character = value; }
        public EmotionSo Emotion { get => _emotion; internal set => _emotion = value; }
    }
}
