using UnityEngine;

namespace Configurations.Blocks
{
    [CreateAssetMenu(menuName = "Blocks/Create ice bonus configuration", order = 0)]
    public class IceBlockConfiguration : ScriptableObject, IBlockConfiguration
    {
        [SerializeField] private float _effectDuration;
        [SerializeField] private float _force;
        [SerializeField] private ParticleSystem _destroyParticleSystem;
        
        public float EffectDuration => _effectDuration;
        public float Force => _force;
        public ParticleSystem DestroyParticleSystem => _destroyParticleSystem;
    }
}