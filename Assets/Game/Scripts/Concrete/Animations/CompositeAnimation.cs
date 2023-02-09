using System.Collections.Generic;
using Abstracts.Animations;
using DG.Tweening;
using UnityEngine;

namespace Concrete.Animations
{
    public class CompositeAnimation : ITransformAnimation
    {
        private readonly IList<ITransformAnimation> _transformAnimations;

        public CompositeAnimation(IList<ITransformAnimation> transformAnimations) => 
            _transformAnimations = transformAnimations;

        public void Start(Transform transform)
        {
            foreach (var animation in _transformAnimations)
            {
                animation.Start(transform);
            }
        }

        public void Stop(Transform transform) => transform.DOKill();
    }
}