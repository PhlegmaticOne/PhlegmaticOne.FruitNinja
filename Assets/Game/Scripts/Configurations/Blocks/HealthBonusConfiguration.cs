using UnityEngine;

namespace Configurations.Blocks
{
    [CreateAssetMenu(menuName = "Blocks/Create heart bonus configuration", order = 0)]
    public class HealthBonusConfiguration : ScriptableObject, IBlockConfiguration
    {
        [SerializeField] private float _multiplyAcceleartionBy;
        [SerializeField] private float _multiplySpeedBy;
        [SerializeField] private int _heartsToGive;
        [SerializeField] private ParticleSystem _onDestroyParticle;

        public float MultiplySpeedBy => _multiplySpeedBy;
        public float MultiplyAccelerationBy => _multiplyAcceleartionBy;
        public int HeartsToGive => _heartsToGive;
        public ParticleSystem OnDestroyParticleSystem => _onDestroyParticle;
    }
}