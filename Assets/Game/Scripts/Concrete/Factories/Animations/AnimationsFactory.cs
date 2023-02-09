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
    }
}