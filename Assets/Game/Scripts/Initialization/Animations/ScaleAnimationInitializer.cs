using Abstracts.Animations;
using Abstracts.Initialization;
using Concrete.Animations;
using Configurations.Base;
using UnityEngine;

namespace Initialization.Animations
{
    public class ScaleAnimationInitializer : InitializerBase<ITransformAnimation>
    {
        [SerializeField] private MinMaxInfo<float> _scaleRange;
        [SerializeField] private MinMaxInfo<float> _durationRange;
        public override ITransformAnimation Create() => 
            new ScaleAnimation(_scaleRange.Min, _scaleRange.Max, _durationRange.Min, _durationRange.Max);
    }
}