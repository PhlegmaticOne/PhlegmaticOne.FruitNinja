using Abstracts.Animations;
using DG.Tweening;
using UnityEngine;

namespace Concrete.Animations
{
    public class ScaleAnimation : ITransformAnimation
    {
        private readonly float _scaleBy;
        private readonly float _duration;

        public ScaleAnimation(float scaleBy, float duration)
        {
            _scaleBy = scaleBy;
            _duration = duration;
        }
        
        public void Start(Transform transform)
        {
            transform
                .DOScale(transform.localScale * _scaleBy, _duration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.Linear);
        }

        public void Stop(Transform transform) => transform.DOKill();
    }
}