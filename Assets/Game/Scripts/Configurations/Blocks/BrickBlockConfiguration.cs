using UnityEngine;

namespace Configurations.Blocks
{
    [CreateAssetMenu(menuName = "Blocks/Create brick configuration", order = 0)]
    public class BrickBlockConfiguration : ScriptableObject, IBlockConfiguration
    {
        [SerializeField] private bool _blocksInput;
        [SerializeField] private ParticleSystem _onCollisionParticleSystem;
        public bool BlocksInput => _blocksInput;
        public ParticleSystem OnCollisionParticleSystem => _onCollisionParticleSystem;
    }
}