using System.Collections.Generic;
using System.Linq;
using Abstracts.Animations;
using Abstracts.Factories;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Concrete.Factories.Animations
{
    public class AnimationsFactory : IFactory<ITransformAnimation>
    {
        private readonly List<ITransformAnimation> _animations;

        public AnimationsFactory(IEnumerable<ITransformAnimation> animations) => 
            _animations = animations.ToList();

        public ITransformAnimation Create()
        {
            var randomIndex = Random.Range(0, _animations.Count + 1);
            return randomIndex == _animations.Count ? CreateCompositeAnimation() : _animations[randomIndex];
        }

        private ITransformAnimation CreateCompositeAnimation()
        {
            var animationsCount = Random.Range(0, _animations.Count + 1);
            var animations = _animations.Take(animationsCount).ToList();
            return new CompositeAnimation(animations);
        }
        
        
        private class CompositeAnimation : ITransformAnimation
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
}