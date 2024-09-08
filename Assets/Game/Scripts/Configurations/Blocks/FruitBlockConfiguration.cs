using UnityEngine;

namespace Configurations.Blocks
{
    [CreateAssetMenu(menuName = "Blocks/Create fruit configuration", order = 0)]
    public class FruitBlockConfiguration : ScriptableObject, IBlockConfiguration
    {
        [SerializeField] private ParticleSystem _juiceParticleSystem;
        [SerializeField] private ParticleSystem _juiceDropsParticleSystem;

        public ParticleSystem JuiceParticleSystem => _juiceParticleSystem;
        public ParticleSystem JuiceDropsParticleSystem => _juiceDropsParticleSystem;
    }
}