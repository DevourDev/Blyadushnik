using DevourDev.Unity.MultiCulture;
using UnityEngine;

namespace DevourDev.Unity
{
    [System.Serializable]
    public class MetaInfo
    {
        [SerializeField] private MultiCulturalText _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Sprite _preview;


        public MetaInfo(MultiCulturalText name, Sprite icon, Sprite preview)
        {
            _name = name;
            _icon = icon;
            _preview = preview;
        }


        public MultiCulturalText Name => _name;
        public Sprite Icon => _icon;
        public Sprite Preview => _preview;


        public static MetaInfo Create(CultureObject culture, string text)
        {
            MultiCulturalText name = MultiCulturalText.Create(culture, text);
            return new(name, null, null);
        }
    }
}
