using TMPro;
using UnityEngine;

namespace Game.Ui
{
    public sealed class SelectorVariantSlot : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private SelectionPanel _parent;
        private int _index;


        public void Init(SelectionPanel parent, int slotIndex, string text)
        {
            _parent = parent;
            _index = slotIndex;
            _text.text = text;
        }

        public void HandleClick()
        {
            _parent.RegisterClick(_index);
        }
    }
}
