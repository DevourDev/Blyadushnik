using Game.Content.GameEntities.Characters;
using Game.Core.CommandsSystem;
using UnityEngine;

namespace Game.Content.Commands
{
    [CreateAssetMenu(menuName = GameAssetMenu.Commands + "Remove Character")]
    public sealed class RemoveCharacterCommand : CommandSo
    {
        [SerializeField] private CharacterSo _character;

        public CharacterSo Character { get => _character; internal set => _character = value; }
    }
}
