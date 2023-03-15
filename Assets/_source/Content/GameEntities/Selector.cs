using System.Collections.Generic;
using DevourDev.Unity.MultiCulture;
using Game.Content.GameEntities.StoryLines;
using UnityEngine;

namespace Game.Content.GameEntities
{
    [System.Serializable]
    public sealed class Selector
    {
        [System.Serializable]
        public sealed class Title
        {
            [SerializeField] private MultiCulturalText _text;


            public Title(MultiCulturalText text)
            {
                _text = text;
            }


            public MultiCulturalText Text => _text;
        }


        [System.Serializable]
        public sealed class Variant
        {
            [SerializeField] private MultiCulturalText _text;
            [SerializeField] private StoryLine _jump;


            public Variant(MultiCulturalText text, StoryLine jump)
            {
                _text = text;
                _jump = jump;
            }


            public MultiCulturalText Text => _text;
            public StoryLine Jump => _jump;
        }


        [SerializeField] private Title _title;
        [SerializeField] private Variant[] _variants;


        public Selector(Title title, Variant[] variants)
        {
            _title = title;
            _variants = variants;
        }


        public Title GetTitle() => _title;

        public IReadOnlyList<Variant> GetVariants() => _variants;
    }
}
