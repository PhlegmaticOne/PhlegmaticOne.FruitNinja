using Abstracts.Animations;
using DG.Tweening;
using UnityEngine;

namespace Concrete.Animations
{
    public class RotateAnimation : ITransformAnimation
    {
        private static Vector3 FullCircle = new Vector3(0, 0, 360);
        private readonly float _duration;
        
        public RotateAnimation(float duration) => _duration = duration;

        public void Start(Transform transform)
        {
            transform
                .DORotate(FullCircle, _duration, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
        }

        public void Stop(Transform transform) => transform.DOKill();
    }
}