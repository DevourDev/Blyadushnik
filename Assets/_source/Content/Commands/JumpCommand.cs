using Game.Content.GameEntities.StoryLines;
using Game.Core.CommandsSystem;
using UnityEngine;

namespace Game.Content.Commands
{

    [CreateAssetMenu(menuName = GameAssetMenu.Commands + "Jump")]
    public sealed class JumpCommand : CommandSo
    {
        [SerializeField] private StoryLine _storyLine;


        public StoryLine StoryLine { get => _storyLine; internal set => _storyLine = value; }
    }


}
