using UnityEngine;

namespace Physics
{
    public abstract class GravityObject : MonoBehaviour
    {
        private static readonly float _baseAcceleration = 8f;
        private Vector3 _speed;
        [SerializeField] private Vector3 _acceleration;

        private void Update()
        {
            Move();
        }

        private void FixedUpdate()
        {
            UpdateSpeed();
        }

        public void SetGravityAcceleration(float gravityAcceleration)
        {
            if (gravityAcceleration > 0)
            {
                gravityAcceleration = -gravityAcceleration;
            }
            OnAccelerationSetting(ref gravityAcceleration);
            _acceleration = new Vector3(_acceleration.x, gravityAcceleration, _acceleration.z);
        }

        public void AddSpeed(Vector3 speed)
        {
            OnSpeedAdding(ref speed);
            _speed += speed;
        }

        public void DisableGravity() => SetGravityAcceleration(0);
        public void EnableDefaultGravity() => SetGravityAcceleration(_baseAcceleration);

        public void SetSpeed(Vector3 speed) => _speed = speed;
        public Vector3 GetSpeed() => _speed;
        public float GetGravityAcceleration() => _acceleration.y;
        
        private void Move() => transform.position += _speed * Time.deltaTime;
        
        private void UpdateSpeed() => _speed += _acceleration * Time.deltaTime;

        protected virtual void OnAccelerationSetting(ref float acceleration) { }
        protected virtual void OnSpeedAdding(ref Vector3 speedToAdd) { }
    }
}