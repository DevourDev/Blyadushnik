using Game.Content.Commands;
using Game.Core.CommandsSystem;
using Game.Ui;
using UnityEngine;

namespace Game.Content.Executors
{
    public sealed class SetBackgroundImageExecutor : CommandExecutorBase<SetBackgroundImageCommand>
    {
        [SerializeField] private SpriteRenderer _sr;
        [SerializeField] private bool _removeAllCharacters = true;
        [SerializeField] private ItemsOnSceneManager _itemsOnSceneManager;


        protected override void ExecuteInherited(SetBackgroundImageCommand command)
        {
            _sr.sprite = command.Sprite;

            if (_removeAllCharacters)
            {
                _itemsOnSceneManager.RemoveAll();
            }
        }
    }
}
