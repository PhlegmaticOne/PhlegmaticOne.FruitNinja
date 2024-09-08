using Abstracts.Animations;
using DG.Tweening;
using UnityEngine;

namespace Concrete.Animations
{
    public class ScaleAnimation : ITransformAnimation
    {
        private readonly float _minScaleBy;
        private readonly float _maxScaleBy;
        private readonly float _minDuration;
        private readonly float _maxDuration;

        public ScaleAnimation(float minScaleBy, float maxScaleBy,
            float minDuration, float maxDuration)
        {
            _minScaleBy = minScaleBy;
            _maxScaleBy = maxScaleBy;
            _minDuration = minDuration;
            _maxDuration = maxDuration;
        }
        
        public void Start(Transform transform)
        {
            var duration = Random.Range(_minDuration, _maxDuration);
            var scaleBy = Random.Range(_minScaleBy, _maxScaleBy);
            transform
                .DOScale(transform.localScale * scaleBy, duration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.Linear);
        }

        public void Stop(Transform transform) => transform.DOKill();
    }
}