using UnityEngine;

namespace Configurations.Blocks
{
    [CreateAssetMenu(menuName = "Blocks/Create bomb configuration", order = 0)]
    public class BombConfiguration : ScriptableObject, IBlockConfiguration
    {
        [SerializeField] private int _heartsToRemove;
        [SerializeField] private float _explosionRadius;
        [SerializeField] private float _explosionPower;
        [SerializeField] private string _onExplosionText;
        [SerializeField] private ParticleSystem _explosionParticle;

        public float ExplosionRadius => _explosionRadius;
        public float ExplosionPower => _explosionPower;
        public string OnExplosionText => _onExplosionText;
        public ParticleSystem ExplosionParticle => _explosionParticle;
        public int HeartsToRemove => _heartsToRemove;
    }
}