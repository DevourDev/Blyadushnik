using Game.Content.GameEntities.Characters.Stats;
using Game.Core.CommandsSystem;
using UnityEngine;

namespace Game.Content.Commands
{
    [CreateAssetMenu(menuName = GameAssetMenu.Commands + "Change Integer Stat Value")]
    public sealed class ChangeIntegerStatValueCommand : CommandSo
    {
        [SerializeField] private IntegerStatSo _stat;
        [SerializeField] private int _delta;


        public IntegerStatSo Stat { get => _stat; internal set => _stat = value; }
        public int Delta { get => _delta; internal set => _delta = value; }
    }
}
