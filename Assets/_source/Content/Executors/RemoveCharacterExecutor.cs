using Game.Content.Commands;
using Game.Core.CommandsSystem;
using Game.Ui;
using UnityEngine;

namespace Game.Content.Executors
{
    public sealed class RemoveCharacterExecutor : CommandExecutorBase<RemoveCharacterCommand>
    {
        [SerializeField] private ItemsOnSceneManager _itemsOnSceneManager;


        protected override void ExecuteInherited(RemoveCharacterCommand command)
        {
            _itemsOnSceneManager.RemoveCharacter(command.Character);
        }
    }
}
