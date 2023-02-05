using UnityEngine;

namespace Physics
{
    public abstract class GravityObject : MonoBehaviour
    {
        private Vector3 _speed;
        private Vector3 _acceleration;

        private float _cameraTopPoint;
        private float _gravityAcceleration = 3f;

        private void Start() => _acceleration = new Vector3(0, _gravityAcceleration, 0);

        private void Update()
        {
            Move();
            DecreaseSpeed();
        }
        
        public void SetGravityAcceleration(float gravityAcceleration) => _gravityAcceleration = gravityAcceleration;

        public void AddSpeed(Vector3 speed) => _speed += speed;
        public void MultiplyX(float multiplier) => _speed.x *= multiplier;
        public Vector3 GetSpeed() => _speed;
        public float GetGravityAcceleration() => _gravityAcceleration;
        
        private void Move() => transform.position += _speed * Time.deltaTime;
        
        private void DecreaseSpeed() => _speed -= _acceleration * Time.deltaTime;
    }
}