using Game.Core.CommandsSystem;
using UnityEngine;

namespace Game.Content.Commands
{
    [CreateAssetMenu(menuName = GameAssetMenu.Commands + "Set Background Image")]
    public sealed class SetBackgroundImageCommand : CommandSo
    {
        [SerializeField] private Sprite _sprite;

        public Sprite Sprite { get => _sprite; internal set => _sprite = value; }
    }


}
