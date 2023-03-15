using System.Collections.Generic;
using Game.Content.GameEntities.Characters;
using UnityEngine;

namespace Game.Ui
{
    public sealed class ItemsOnSceneManager : MonoBehaviour
    {
        [SerializeField] private CharacterOnScene[] _characterPrefabs;
        [SerializeField] private Transform _parent;
        [SerializeField] private float _offset = 1f;
        [SerializeField] private bool _rightToLeft = true; //!!!

        private readonly Dictionary<CharacterSo, CharacterOnScene> _characterPrefabsDict = new();
        private readonly List<CharacterOnScene> _charactersOnScene = new();


        private void Awake()
        {
            foreach (var cp in _characterPrefabs)
            {
                _characterPrefabsDict.Add(cp.Reference, cp);
            }
        }


        public void PlaceCharacter(CharacterSo character)
        {
            if (CharacterExistOnScene(character, out _))
                return;

            PlaceCharacterHelper(character, _charactersOnScene.Count);
        }


        public void PlaceCharacter(CharacterSo character, int order)
        {
            if (CharacterExistOnScene(character, out _))
                return;

            PlaceCharacterHelper(character, order);
        }

        public void RemoveCharacter(CharacterSo character)
        {
            if (!CharacterExistOnScene(character, out var index))
                return;

            Destroy(_charactersOnScene[index].gameObject);
            _charactersOnScene.RemoveAt(index);
            UpdateCharactersPositions();
        }

        public void RemoveAll()
        {
            var list = _charactersOnScene;
            var count = list.Count;

            for (int i = 0; i < count; i++)
            {
                Destroy(list[i].gameObject);
            }

            list.Clear();
        }

        private void PlaceCharacterHelper(CharacterSo character, int order)
        {
            var charInst = Instantiate(_characterPrefabsDict[character]);
            charInst.transform.parent = _parent;

            if (order > _charactersOnScene.Count)
                order = _charactersOnScene.Count;

            _charactersOnScene.Insert(order, charInst);
            UpdateCharactersPositions();
        }

        private void UpdateCharactersPositions()
        {
            var list = _charactersOnScene;
            var count = list.Count;

            var cam = Camera.main;

            Vector3 min = cam.ViewportToWorldPoint(Vector3.zero);
            Vector3 max = cam.ViewportToWorldPoint(Vector3.one);

            float minX = min.x + _offset;
            float maxX = max.x - _offset;

            if (_rightToLeft)
            {
                (minX, maxX) = (maxX, minX);
            }

            Vector3 pos = _parent.position;

            float length = maxX - minX;
            float delta = length / (count + 1);

            for (int i = 0; i < count; i++)
            {
                float posX = minX + delta * (i + 1);
                pos.x = posX;
                list[i].transform.position = pos;
            }
        }

        private bool CharacterExistOnScene(CharacterSo character, out int index)
        {
            var list = _charactersOnScene;
            var count = list.Count;

            for (index = 0; index < count; index++)
            {
                if (list[index].Reference == character)
                    return true;
            }

            return false;
        }
    }
}