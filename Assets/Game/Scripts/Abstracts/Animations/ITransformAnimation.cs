using UnityEngine;

namespace Abstracts.Animations
{
    public interface ITransformAnimation
    {
        void Start(Transform transform);
        void Stop(Transform transform);
    }
}