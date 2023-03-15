using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Game.Core.CommandsSystem
{
    public abstract class CommandExecutorBase : MonoBehaviour, ICommandExecutor
    {
        public abstract System.Type CommandType { get; }


        public abstract void Execute(object command);
    }


    public abstract class CommandExecutorBase<T> : CommandExecutorBase
    {
        public sealed override Type CommandType => typeof(T);


        public sealed override void Execute(object command)
        {
            if (command.GetType() != CommandType)
                throw new ArgumentException($"invalid type - {command.GetType()} (expected {CommandType})", nameof(command));

            ExecuteInherited((T)command);
        }


        protected abstract void ExecuteInherited(T command);
    }
}
