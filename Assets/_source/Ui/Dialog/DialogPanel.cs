using System.Collections;
using TMPro;
using UnityEngine;

namespace Game.Ui
{
    public sealed class DialogPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _authorNameText;
        [SerializeField] private TextMeshProUGUI _messageText;
        [SerializeField] private float _symbolsPerSecond = 35f;


        private string _authorName;
        private string _message;
        private Coroutine _textRevealing;


        public void Say(string authorName, string message)
        {
            _authorName = authorName;
            _message = message;

            if (_textRevealing != null)
            {
                StopCoroutine(_textRevealing);
            }

            _authorNameText.text = authorName;
            _textRevealing = StartCoroutine(RevealCharacters(_messageText, _message));
        }

        public void SkipRevealing()
        {
            _messageText.maxVisibleCharacters = _message.Length;
            _messageText.text = _message;
        }

        private IEnumerator RevealCharacters(TMP_Text textComponent, string text)
        {
            textComponent.text = text;
            textComponent.ForceMeshUpdate();

            int totalVisibleCharacters = text.Length;

            float visibleFloat = 0;
            textComponent.maxVisibleCharacters = 0;

            for (int visibleCount = 0; visibleCount < totalVisibleCharacters;)
            {
                visibleFloat += _symbolsPerSecond * Time.deltaTime;
                int tmp = visibleCount;
                visibleCount = (int)visibleFloat;

                if (tmp != visibleCount)
                    textComponent.maxVisibleCharacters = visibleCount;

                yield return null;
            }

            _textRevealing = null;
        }
    }
}
