using DevourDev.Unity.ScriptableObjects;
using Game.Core.CommandsSystem;
using UnityEngine;

namespace Game.Content.GameEntities.StoryLines
{
    [CreateAssetMenu(menuName = GameAssetMenu.GameEntities + "Story Line")]
    public sealed class StoryLine : SoDatabaseElement
    {
        [SerializeField] private CommandSo[] _commands;


        public int Count => _commands == null ? 0 : _commands.Length;

        public CommandSo this[int index] => _commands[index];


        internal void Init(CommandSo[] commands)
        {
            _commands = commands;
        }
    }
}
