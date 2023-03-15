using DevourDev.Unity.MultiCulture;
using Game.Content.GameEntities.Characters;
using Game.Core.CommandsSystem;
using UnityEngine;

namespace Game.Content.Commands
{
    [CreateAssetMenu(menuName = GameAssetMenu.Commands + "Say")]
    public sealed class SayCommand : CommandSo
    {
        [SerializeField] private CharacterSo _author;
        [SerializeField] private MultiCulturalText _message;


        public CharacterSo Author { get => _author; internal set => _author = value; }
        public MultiCulturalText Message { get => _message; internal set => _message = value; }
    }


}
