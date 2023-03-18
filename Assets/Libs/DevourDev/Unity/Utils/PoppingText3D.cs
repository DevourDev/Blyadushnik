using TMPro;
using UnityEngine;

namespace DevourDev.Unity.Utils
{
    public class PoppingText3D : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _textMesh;
        [SerializeField] private float _lifeTime = 2f;
        [SerializeField] private float _speed = 1.5f;
        [SerializeField] private AnimationCurve _speedCurve;
        [SerializeField] private AnimationCurve _transparencyCurve;
        [SerializeField] private AnimationCurve _scaleCurve;
        [SerializeField] private Vector3 _direction = Vector3.up;
        [SerializeField] private bool _relativeDirection;

        private float _lifeTimeLeft;
        private Vector3 _initialScale;


        public float LifeTime
        {
            get => _lifeTime;
            set
            {
                _lifeTime = value;
                _lifeTimeLeft = value;
            }
        }


        public float Speed { get => _speed; set => _speed = value; }

        public AnimationCurve SpeedCurve { get => _speedCurve; set => _speedCurve = value; }
        public AnimationCurve TransparencyCurve { get => _transparencyCurve; set => _transparencyCurve = value; }
        public AnimationCurve ScaleCurve { get => _scaleCurve; set => _scaleCurve = value; }

        public Vector3 Direction { get => _direction; set => _direction = value; }
        public bool RelativeDirection { get => _relativeDirection; set => _relativeDirection = value; }


        private void Awake()
        {
            _lifeTimeLeft = _lifeTime;
            _initialScale = transform.localScale;
        }

        private void Start()
        {
            Evaluate(0);
        }


        private void Update()
        {
            _lifeTimeLeft -= Time.deltaTime;

            if (_lifeTimeLeft > 0)
            {
                float t = Mathf.InverseLerp(_lifeTime, 0, _lifeTimeLeft);
                Evaluate(t);
                return;
            }

            //return to pool

            Destroy(gameObject);
        }


        public void SetText(string text) => _textMesh.text = text;
        public void SetColor(Color color) => _textMesh.color = color;
        public void SetFontSize(float size) => _textMesh.fontSize = size;
        public void AllowFontAutoSizing(bool allow) => _textMesh.enableAutoSizing = allow;


        public TMP_Text GetTextComponent() => _textMesh;

        private void Evaluate(float t)
        {
            float speed = _speed * _speedCurve.Evaluate(t);
            Vector3 direction = _direction;

            if (_relativeDirection)
                direction = transform.rotation * _direction;

            var movement = speed * Time.deltaTime * direction;
            transform.position += movement;
            float scale = _scaleCurve.Evaluate(t);
            transform.localScale = _initialScale * scale;
            Color color = _textMesh.color;
            color.a = _transparencyCurve.Evaluate(t);

            _textMesh.color = color;
        }
    }
}
