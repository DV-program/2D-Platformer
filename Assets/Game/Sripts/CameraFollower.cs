using Assets.Game.Interfaces;
using Assets.Game.Sripts.Interfaces;
using UnityEngine;
namespace Assets.Game.Sripts
{
    public class CameraFollower
    {
        private Transform _targetTransform;
        private Transform _cameraTransform;
        private Vector3 _offcet;
        private float _smothing = 1f;
        public CameraFollower(Transform targetTransform, Transform cameraTransform, Vector3 offcet, float smothing)
        {
            _targetTransform = targetTransform;
            _cameraTransform = cameraTransform;
            _offcet = offcet;
            _smothing = smothing;
            EventBus.Instance.FixedUpdate += OnMove;
        }
        private void OnMove()
        {
            Vector3 nextPosition = Vector3.Lerp(_cameraTransform.position, _targetTransform.position + _offcet, Time.fixedDeltaTime * _smothing);
            _cameraTransform.position = nextPosition;
        }
        public void Disable()
        {
            EventBus.Instance.FixedUpdate -= OnMove;
        }
    }
}