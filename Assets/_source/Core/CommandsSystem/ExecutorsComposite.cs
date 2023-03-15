using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core.CommandsSystem
{
    public sealed class ExecutorsComposite : MonoBehaviour, ICommandExecutor
    {
        [SerializeField] private CommandExecutorBase[] _executors;


        private readonly Dictionary<System.Type, ICommandExecutor> _executorsDict = new();


        public Type CommandType => throw new NotSupportedException("Not supported in Composites");


        private void Awake()
        {
            foreach (var executor in _executors)
            {
                _executorsDict.Add(executor.CommandType, executor);
            }
        }


        public void Execute(object command)
        {
            if (!_executorsDict.TryGetValue(command.GetType(), out var executor))
                throw new KeyNotFoundException($"unable to find executor for cmd {command}");

            executor.Execute(command);
        }
    }
}
