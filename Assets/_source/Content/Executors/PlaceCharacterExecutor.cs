using Game.Content.Commands;
using Game.Content.GameEntities.Characters;
using Game.Core.CommandsSystem;
using Game.Ui;
using UnityEngine;

namespace Game.Content.Executors
{
    public sealed class PlaceCharacterExecutor : CommandExecutorBase<PlaceCharacterCommand>
    {
        [SerializeField] private ItemsOnSceneManager _itemsOnSceneManager;
        [SerializeField] private CharacterSo _mainCharacter;


        protected override void ExecuteInherited(PlaceCharacterCommand command)
        {
            if (command.Character == _mainCharacter)
                _itemsOnSceneManager.PlaceCharacter(command.Character, 0);
            else
                _itemsOnSceneManager.PlaceCharacter(command.Character);
        }
    }
}
