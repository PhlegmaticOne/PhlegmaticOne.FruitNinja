using Abstracts.Animations;
using Abstracts.Initialization;
using Concrete.Animations;
using Configurations.Animations;
using Configurations.Base;
using UnityEngine;

namespace Initialization.Animations
{
    public class ScaleAnimationInitializer : InitializerBase<ITransformAnimation>
    {
        [SerializeField] private ScaleAnimationConfiguration _scaleAnimationConfiguration;
        public override ITransformAnimation Create() => 
            new ScaleAnimation(
                _scaleAnimationConfiguration.ScaleRange.Min,
                _scaleAnimationConfiguration.ScaleRange.Max,
                _scaleAnimationConfiguration.DurationRange.Min,
                _scaleAnimationConfiguration.DurationRange.Max);
    }
}