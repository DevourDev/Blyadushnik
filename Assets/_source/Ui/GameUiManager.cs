using UnityEngine;

namespace Game.Ui
{
    public sealed class GameUiManager : MonoBehaviour
    {
        [SerializeField] private DialogPanel _dialogPanel;

        private static GameUiManager _inst;


        public static DialogPanel DialogPanel => _inst._dialogPanel;


        private void Awake()
        {
            _inst = this;
        }

        private void OnDestroy()
        {
            if(_inst == this)
            {
                _inst = null;
            }
        }
    }
}
