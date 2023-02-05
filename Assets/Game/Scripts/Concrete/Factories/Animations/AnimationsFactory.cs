using System;
using System.Collections.Generic;
using System.Linq;
using Abstracts.Animations;
using Abstracts.Factories;
using Concrete.Animations;
using Random = UnityEngine.Random;

namespace Concrete.Factories.Animations
{
    public class AnimationsFactory : IFactory<ITransformAnimation>
    {
        private readonly List<Func<ITransformAnimation>> _animationFuncs;

        public AnimationsFactory(IEnumerable<Func<ITransformAnimation>> animationFuncs)
        {
            _animationFuncs = animationFuncs.ToList();
            AddCompositeAnimation();
        }
        
        public ITransformAnimation Create()
        {
            var randomIndex = Random.Range(0, _animationFuncs.Count);
            return _animationFuncs[randomIndex]();
        }

        private void AddCompositeAnimation()
        {
            _animationFuncs.Add(() =>
            {
                var animationsCount = Random.Range(0, _animationFuncs.Count + 1);
                var animations = _animationFuncs
                    .Take(animationsCount)
                    .Select(x => x());
                return new CompositeAnimation(animations);
            });
        }
    }
}