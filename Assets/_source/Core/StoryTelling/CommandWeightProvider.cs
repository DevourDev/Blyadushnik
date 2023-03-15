using UnityEngine;

namespace Game.Core.StoryTelling
{
    [CreateAssetMenu(menuName = GameAssetMenu.Root + "StoryTelling/Command Weight Provider")]
    public sealed class CommandWeightProvider : ScriptableObject
    {
        [System.Serializable]
        private struct CommandWeight
        {
            public UnityEngine.Object Command;
            public int Weight;
        }


        [SerializeField] private int _defaultWeight;
        [SerializeField] private CommandWeight[] _commandWeights;


        public int GetWeight(object command)
        {
            var type = command.GetType();

            foreach (var cw in _commandWeights)
            {
                if (cw.Command.GetType() == type)
                    return cw.Weight;
            }

            return _defaultWeight;
        }
    }
}
