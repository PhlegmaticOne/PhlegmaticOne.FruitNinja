using Configurations.Base;
using UnityEngine;

namespace Configurations.Animations
{
    [CreateAssetMenu(menuName = "Animations/Create rotate animation configuration", order = 0)]
    public class RotateAnimationConfiguration : ScriptableObject
    {
        [SerializeField] private MinMaxInfo<float> _durationRange;
        
        public MinMaxInfo<float> DurationRange => _durationRange;
    }
}