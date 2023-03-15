using Game.Content.GameEntities.Characters;
using Game.Core.CommandsSystem;
using UnityEngine;

namespace Game.Content.Commands
{
    [CreateAssetMenu(menuName = GameAssetMenu.Commands + "Place Character")]
    public sealed class PlaceCharacterCommand : CommandSo
    {
        [SerializeField] private CharacterSo _character;

        public CharacterSo Character { get => _character; internal set => _character = value; }
    }
}
