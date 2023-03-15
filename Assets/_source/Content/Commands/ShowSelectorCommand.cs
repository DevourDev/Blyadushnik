using Game.Content.GameEntities;
using Game.Core.CommandsSystem;
using UnityEngine;

namespace Game.Content.Commands
{
    [CreateAssetMenu(menuName = GameAssetMenu.Commands + "Show Selector")]
    public sealed class ShowSelectorCommand : CommandSo
    {
        [SerializeField] Selector _selector;


        public Selector Selector { get => _selector; internal set => _selector = value; }
    }
}
