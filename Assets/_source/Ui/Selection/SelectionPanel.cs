using System.Collections.Generic;
using Game.Content.GameEntities;
using Game.Content.GameEntities.StoryLines;
using Game.Core.StoryTelling;
using TMPro;
using UnityEngine;

namespace Game.Ui
{
    public sealed class SelectionPanel : MonoBehaviour
    {
        [SerializeField] private SelectorVariantSlot _slotPrefab;
        [SerializeField] private Transform _slotsParent;

        [SerializeField] private TMP_Text _titleText;

        private readonly List<SelectorVariantSlot> _slots = new();
        private readonly List<StoryLine> _jumps = new();


        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }


        public void BuildSelector(Selector selector)
        {
            DestroySlots();

            string title = string.Empty;
            var title0 = selector.GetTitle();

            if (title0 != null && title0.Text != null)
                title = title0.Text.Get();

            _titleText.text = title;

            var variants = selector.GetVariants();

            for (int i = 0; i < variants.Count; i++)
            {
                Selector.Variant v = variants[i];
                var slot = Instantiate(_slotPrefab);
                slot.transform.parent = _slotsParent;
                slot.Init(this, i, v.Text.Get());
                _slots.Add(slot);
                _jumps.Add(v.Jump);
            }

            Show();
        }


        private void DestroySlots()
        {
            _jumps.Clear();

            foreach (var s in _slots)
            {
                Destroy(s.gameObject);
            }

            _slots.Clear();
        }

        internal void RegisterClick(int slotIndex)
        {
            Hide();
            NovelManager.JumpToStoryLine(_jumps[slotIndex], 0);
        }
    }
}
