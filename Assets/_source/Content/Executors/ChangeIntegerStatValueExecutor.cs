using Game.Content.Commands;
using Game.Core;
using Game.Core.CommandsSystem;

namespace Game.Content.Executors
{
    public sealed class ChangeIntegerStatValueExecutor : CommandExecutorBase<ChangeIntegerStatValueCommand>
    {
        protected override void ExecuteInherited(ChangeIntegerStatValueCommand command)
        {
            Player.IntStats.ChangeStatValue(command.Stat, command.Delta);
        }
    }
}
