using Abstracts.Animations;
using Abstracts.Initialization;
using Concrete.Animations;
using Configurations.Base;
using UnityEngine;

namespace Initialization.Animations
{
    public class RotationAnimationInitializer : InitializerBase<ITransformAnimation>
    {
        [SerializeField] private MinMaxInfo<float> _durationRange;
        public override ITransformAnimation Create() => new RotateAnimation(_durationRange.Min, _durationRange.Max);
    }
}