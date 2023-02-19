using UnityEngine;

namespace Configurations.Blocks
{
    [CreateAssetMenu(menuName = "Blocks/Create magnet bonus configuration", order = 0)]
    public class MagnetConfiguration : ScriptableObject, IBlockConfiguration
    {
        [SerializeField] private float _magnetForce;
        [SerializeField] private float _duration;
        [SerializeField] private float _radius;
        [SerializeField] private ParticleSystem _destroyParticleSystem;

        public float MagnetForce => _magnetForce;
        public float Duration => _duration;
        public float Radius => _radius;
        public ParticleSystem DestroyParticleSystem => _destroyParticleSystem;
    }
}