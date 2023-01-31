using UnityEngine;

namespace Physics
{
    public abstract class GravityObject : MonoBehaviour
    {
        private MovementBase _movement;

        private Vector3 _speed;
        private Vector3 _acceleration;

        private float _gravityAcceleration = 2f;

        protected void Initialize(MovementBase movement)
        {
            _movement = movement;
            _acceleration = new Vector3(0, _gravityAcceleration, 0);
        }

        private void Update()
        {
            var position = transform.position;
            _movement.DeltaMove(ref position, ref _speed, ref _acceleration);
            transform.position = position;
        }

        public void SetGravityAcceleration(float gravityAcceleration) => _gravityAcceleration = gravityAcceleration;

        public void AddSpeed(Vector3 speed) => _speed += speed;
    }
}