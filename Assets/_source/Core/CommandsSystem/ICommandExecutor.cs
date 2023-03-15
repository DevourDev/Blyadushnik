namespace Game.Core.CommandsSystem
{
    public interface ICommandExecutor
    {
        System.Type CommandType { get; }


        void Execute(object command);
    }
}
