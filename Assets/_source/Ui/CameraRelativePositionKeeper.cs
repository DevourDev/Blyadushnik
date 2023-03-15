using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

namespace Game.Ui
{
    public sealed class CameraRelativePositionKeeper : MonoBehaviour
    {
        [SerializeField] private Vector2 _relativePosition = Vector2.one / 2f;
        [SerializeField] private float _z = 0f;
#if UNITY_EDITOR
        [SerializeField] private bool _enableGizmos = true;
        [SerializeField] private Color _gizmosColor = Color.yellow;
        [SerializeField] private float _gizmosSphereRadius = 0.4f;
#endif

#if UNITY_EDITOR
        //with checks == 14
        //without (only fin pos check) == 13
        [SerializeField] private bool _withChecks = true;
        [SerializeField] private long _max;
        [SerializeField] private long _avg;

        private readonly Stopwatch _sw = new();
        private readonly long[] _times = new long[2048];
        private int _index;
        private bool _filled;
#endif

        private Camera _cam;
        private Vector3 _prevPos;
        private float _prevSize;

        private Vector2 _prevRelPos;
        private Vector3 _prevPoint;


        public Vector2 RelativePosition { get => _relativePosition; set => _relativePosition = value; }


#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (!_enableGizmos || Application.isPlaying)
                return;

            Gizmos.color = _gizmosColor;
            var pos = Camera.main.ViewportToWorldPoint(_relativePosition);
            pos.z = _z;

            Gizmos.DrawSphere(pos, _gizmosSphereRadius);
        }
#endif

        private void Awake()
        {
            _cam = Camera.main;

            var tr = _cam.transform;
            var pos = tr.position;
            var size = _cam.orthographicSize;

            _prevPoint = pos;
            _prevSize = size;
            _prevRelPos = _relativePosition;
            _prevPoint = _cam.ViewportToWorldPoint(_relativePosition);

            transform.position = _prevPoint;
        }


        private void Update()
        {
            _sw.Restart();

            if (_withChecks)
            {
                EnsurePositionIsActual();
            }
            else
            {
                var pos = _cam.ViewportToWorldPoint(_relativePosition);
                pos.z = _z;

                if (_prevPos != pos)
                {
                    _prevPos = pos;
                    transform.position = pos;
                }
            }

            _sw.Stop();

            if (_index == _times.Length)
            {
                _index = 0;
                _filled = true;
                _max = -1;
            }

            var elapsed = _sw.ElapsedTicks;

            if (elapsed > _max)
                _max = elapsed;

            _times[_index] = elapsed;
            ++_index;

            if (_filled)
            {
                _avg = (long)_times.Average();
            }
        }


        public void EnsurePositionIsActual()
        {
            var tr = _cam.transform;
            var pos = tr.position;
            var size = _cam.orthographicSize;

            if (_prevRelPos != _relativePosition || pos != _prevPos || size != _prevSize)
            {
                _prevPos = pos;
                _prevSize = size;
                _prevRelPos = _relativePosition;
                _prevPoint = _cam.ViewportToWorldPoint(_relativePosition);
                _prevPoint.z = _z;
                transform.position = _prevPoint;
            }
        }
    }
}
