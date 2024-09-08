using Configurations.Base;
using UnityEngine;

namespace Configurations.Animations
{
    [CreateAssetMenu(menuName = "Animations/Create scale animation configuration", order = 0)]
    public class ScaleAnimationConfiguration : ScriptableObject
    {
        [SerializeField] private MinMaxInfo<float> _scaleRange;
        [SerializeField] private MinMaxInfo<float> _durationRange;

        public MinMaxInfo<float> ScaleRange => _scaleRange;
        public MinMaxInfo<float> DurationRange => _durationRange;
    }
}