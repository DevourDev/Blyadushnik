using Game.Content.Commands;
using Game.Core.CommandsSystem;
using UnityEngine;

namespace Game.Content.Executors
{
    public sealed class PlaySoundExecutor : CommandExecutorBase<PlaySoundCommand>
    {
        [SerializeField] private AudioSource _audioSource;


        protected override void ExecuteInherited(PlaySoundCommand command)
        {
            _audioSource.PlayOneShot(command.Sound);
        }
    }
}
