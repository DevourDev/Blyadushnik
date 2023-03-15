using Game.Content.Commands;
using Game.Core.CommandsSystem;
using Game.Ui;
using UnityEngine;

namespace Game.Content.Executors
{
    public sealed class SayExecutor : CommandExecutorBase<SayCommand>
    {
        [SerializeField] private DialogPanel _dialogPanel;


        protected override void ExecuteInherited(SayCommand command)
        {
            string author = string.Empty;
            string msg = command.Message.Get();

            if (command.Author != null)
                author = command.Author.CharacterName.Get();

            _dialogPanel.Say(author, msg);
        }
    }
}
