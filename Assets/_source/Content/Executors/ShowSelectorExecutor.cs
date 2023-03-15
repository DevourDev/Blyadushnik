using Game.Content.Commands;
using Game.Core.CommandsSystem;
using Game.Ui;
using UnityEngine;

namespace Game.Content.Executors
{
    public sealed class ShowSelectorExecutor : CommandExecutorBase<ShowSelectorCommand>
    {
        [SerializeField] private SelectionPanel _selectionPanel;


        protected override void ExecuteInherited(ShowSelectorCommand command)
        {
            _selectionPanel.BuildSelector(command.Selector);
        }
    }
}
