using Game.Core.CommandsSystem;
using UnityEngine;

namespace Game.Content.Commands
{
    [CreateAssetMenu(menuName = GameAssetMenu.Commands + "Play Sound")]
    public sealed class PlaySoundCommand : CommandSo
    {
        [SerializeField] private AudioClip _sound;


        public AudioClip Sound { get => _sound; internal set => _sound = value; }
    }


}
