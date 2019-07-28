using Common.Help;
using UnityEngine;

namespace Game
{
    public class CameraController : Singleton<CameraController>
    {
        private Transform _transform;
        private float _moveDelta;

        protected override void Start()
        {
            base.Start();
            _transform = transform;
            Player.Instance.MoveStarted += OnPlayerMoveStarted;            
        }
        
        private void FixedUpdate()
        {
            var position = _transform.position;
            position.z += _moveDelta;
            _transform.position = position;
        }

        private void OnPlayerMoveStarted()
        {
            Player.Instance.MoveStarted -= OnPlayerMoveStarted;
            _moveDelta = 0.1f;
        }
    }
}