using UnityEngine;

namespace Physics
{
    public abstract class MovementBase : MonoBehaviour
    {
        public abstract void DeltaMove(ref Vector3 position, ref Vector3 speed, ref Vector3 acceleration);
    }
}