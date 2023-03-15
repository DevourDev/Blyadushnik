using UnityEngine;

namespace Game.Ui
{
    public sealed class CameraRelativePositionKeeper : MonoBehaviour
    {
        [SerializeField] private Vector3 _relativePos = Vector3.one / 2f;
        [SerializeField] private bool _overrideZ = true;
        [SerializeField] private float _z = 0f;
#if UNITY_EDITOR
        [SerializeField] private bool _enableGizmos = true;
        [SerializeField] private Color _gizmosColor = Color.yellow;
        [SerializeField] private float _gizmosSphereRadius = 0.4f;
#endif

        private Camera _cam;
        private Vector3 _prevWorldPos;


        public Vector3 RelativePosition { get => _relativePos; set => _relativePos = value; }


#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (!_enableGizmos)
                return;

            Gizmos.color = _gizmosColor;
            var pos = Camera.main.ViewportToWorldPoint(_relativePos);

            if (_overrideZ)
                pos.z = _z;

            Gizmos.DrawSphere(pos, _gizmosSphereRadius);
        }
#endif

        private void Awake()
        {
            _cam = Camera.main;

            var pos = _cam.ViewportToWorldPoint(_relativePos);

            if (_overrideZ)
                pos.z = _z;

            _prevWorldPos = pos;
            transform.position = pos;
        }


        private void Update()
        {
            var pos = _cam.ViewportToWorldPoint(_relativePos);

            if (_overrideZ)
                pos.z = _z;

            if (_prevWorldPos != pos)
            {
                _prevWorldPos = pos;
                transform.position = pos;
            }
        }
    }
}
