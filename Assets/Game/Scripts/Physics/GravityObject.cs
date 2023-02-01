using UnityEngine;

namespace Physics
{
    public abstract class GravityObject : MonoBehaviour
    {
        private Vector3 _speed;
        private Vector3 _acceleration;

        private float _cameraTopPoint;
        private float _distanceFromTop = 1f;
        private float _gravityAcceleration = 3f;

        private void Start()
        {
            _cameraTopPoint = Camera.main.transform.position.y + Camera.main.orthographicSize;
            _acceleration = new Vector3(0, _gravityAcceleration, 0);
        }

        private void Update()
        {
            while(CanGoOutOfScreen())
            {
                DecreaseSpeed();
            }
            
            Move();
            DecreaseSpeed();
        }
        
        public void SetGravityAcceleration(float gravityAcceleration) => _gravityAcceleration = gravityAcceleration;

        public void AddSpeed(Vector3 speed) => _speed += speed;
        public Vector3 GetSpeed() => _speed;
        
        private void Move() => transform.position += _speed * Time.deltaTime;
        
        private void DecreaseSpeed() => _speed -= _acceleration * Time.deltaTime;

        private bool CanGoOutOfScreen() => transform.position.y + _distanceFromTop >= _cameraTopPoint && _speed.y > 0;
    }
}