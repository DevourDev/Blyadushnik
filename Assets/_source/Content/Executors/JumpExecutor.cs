using Game.Content.Commands;
using Game.Core.CommandsSystem;
using Game.Core.StoryTelling;

namespace Game.Content.Executors
{
    public sealed class JumpExecutor : CommandExecutorBase<JumpCommand>
    {
        protected override void ExecuteInherited(JumpCommand command)
        {
            NovelManager.JumpToStoryLine(command.StoryLine, 0);
        }
    }
}
