using UnityEngine;

namespace Configurations
{
    [CreateAssetMenu(menuName = "Create debufs configuration", order = 0)]
    public class ExtraBlockConfiguration : ScriptableObject
    {
        [SerializeField] private BlockInfo _blockInfo;
        [SerializeField] private float _spawnInPackageProbability;
        [SerializeField] private float _spawnCountInPackagePercentage;

        public BlockInfo BlockInfo => _blockInfo;
        public float SpawnInPackageProbability => _spawnInPackageProbability;
        public float SpawnCountInPackagePercentage => _spawnCountInPackagePercentage;
    }
}