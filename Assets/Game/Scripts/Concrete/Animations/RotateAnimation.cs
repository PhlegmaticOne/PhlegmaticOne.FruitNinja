using Abstracts.Animations;
using DG.Tweening;
using UnityEngine;

namespace Concrete.Animations
{
    public class RotateAnimation : ITransformAnimation
    {
        private readonly float _minDuration;
        private readonly float _maxDuration;
        private static readonly Vector3 FullCircle = new Vector3(0, 0, 360);
        
        public RotateAnimation(float minDuration, float maxDuration)
        {
            _minDuration = minDuration;
            _maxDuration = maxDuration;
        }

        public void Start(Transform transform)
        {
            var duration = Random.Range(_minDuration, _maxDuration);
            var direction = Random.Range(0, 2) == 0 ? 1 : -1;
            
            transform
                .DORotate(FullCircle * direction, duration, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
        }

        public void Stop(Transform transform) => transform.DOKill();
    }
}