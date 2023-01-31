using UnityEngine;

namespace Physics
{
    public class GravityMovement : MovementBase
    {
        private float _cameraTopPoint;
        private float _distanceFromTop = 1f;
        
        private void Start()
        {
            _cameraTopPoint = Camera.main.transform.position.y + Camera.main.orthographicSize;
        }

        public override void DeltaMove(ref Vector3 position, ref Vector3 speed, ref Vector3 acceleration)
        {
            while(CanGoOutOfScreen(position, speed))
            {
                DecreaseSpeed(ref speed, acceleration);
            }
            
            Move(ref position, speed, acceleration);
            DecreaseSpeed(ref speed, acceleration);
        }
        
        private void Move(ref Vector3 position, Vector3 speed, Vector3 acceleration) =>
            position += speed * Time.deltaTime;
        
        private void DecreaseSpeed(ref Vector3 speed, Vector3 acceleration) => speed -= acceleration * Time.deltaTime;

        private bool CanGoOutOfScreen(Vector3 position, Vector3 speed) =>
            position.y + _distanceFromTop >= _cameraTopPoint && speed.y > 0;
    }
}