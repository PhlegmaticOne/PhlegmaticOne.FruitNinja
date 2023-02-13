using UnityEngine;

namespace Physics
{
    public abstract class GravityObject : MonoBehaviour
    {
        private Vector3 _speed;
        private Vector3 _acceleration;

        private void Update()
        {
            Move();
            UpdateSpeed();
        }
        
        public void SetGravityAcceleration(float gravityAcceleration)
        {
            if (gravityAcceleration > 0)
            {
                gravityAcceleration = -gravityAcceleration;
            }
            _acceleration = new Vector3(_acceleration.x, gravityAcceleration, _acceleration.y);
        }

        public void AddSpeed(Vector3 speed) => _speed += speed;
        public void SetSpeed(Vector3 speed) => _speed = speed;
        public Vector3 GetSpeed() => _speed;
        public float GetGravityAcceleration() => _acceleration.y;
        
        private void Move() => transform.position += _speed * Time.deltaTime;
        
        private void UpdateSpeed() => _speed += _acceleration * Time.deltaTime;
    }
}