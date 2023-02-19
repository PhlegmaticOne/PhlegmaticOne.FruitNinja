using Abstracts.Animations;
using Abstracts.Initialization;
using Concrete.Animations;
using Configurations.Animations;
using UnityEngine;

namespace Initialization.Animations
{
    public class RotationAnimationInitializer : InitializerBase<ITransformAnimation>
    {
        [SerializeField] private RotateAnimationConfiguration _rotateAnimationConfiguration;
        public override ITransformAnimation Create() =>
            new RotateAnimation(_rotateAnimationConfiguration.DurationRange.Min,
                _rotateAnimationConfiguration.DurationRange.Max);
    }
}