using Game.Content.GameEntities.StoryLines;
using Game.Core.CommandsSystem;
using UnityEngine;

namespace Game.Core.StoryTelling
{


    public sealed class NovelManager : MonoBehaviour
    {
        [SerializeField] private StoryLine _initialStoryLine;
        [SerializeField] private ExecutorsComposite _executorsComposite;
        [SerializeField] private CommandWeightProvider _commandWeightProvider;
        [SerializeField] private int _stopNextWeight = 10;

        private static NovelManager _inst;
        private static StoryLine _currentStoryLine;
        private static int _commandIndex;
        private static bool _inGoNextLoop;


        internal bool InGoNextLoop => _inGoNextLoop;


        private void Awake()
        {
            _inst = this;
            _currentStoryLine = _initialStoryLine;
            _commandIndex = -1;
        }

        private void Start()
        {
            GoNext();
        }


        private void OnDestroy()
        {
            if (_inst == this)
            {
                _inst = null;
            }
        }


        public static void GoNext()
        {
            _inGoNextLoop = true;

            for (; ; )
            {
                var cmd = GoNextInternal();
                var weight = _inst._commandWeightProvider.GetWeight(cmd);

                if (weight >= _inst._stopNextWeight)
                    break;
            }

            _inGoNextLoop = false;
        }


        private static CommandSo GoNextInternal()
        {
            ++_commandIndex;
            Debug.Log(_commandIndex);
            var cmd = _currentStoryLine[_commandIndex];
            _inst._executorsComposite.Execute(cmd);
            return cmd;
        }


        internal static void JumpToStoryLine(StoryLine storyLine, int cmdIndex)
        {
            _currentStoryLine = storyLine;
            _commandIndex = cmdIndex;

            --_commandIndex;

            if (!_inGoNextLoop)
                GoNext();
        }
    }
}
