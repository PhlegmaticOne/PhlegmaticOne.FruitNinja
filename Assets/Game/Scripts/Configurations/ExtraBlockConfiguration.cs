using UnityEngine;

namespace Configurations
{
    [CreateAssetMenu(menuName = "BlocksInfo/Create extra block configuration", order = 0)]
    public class ExtraBlockConfiguration : ScriptableObject
    {
        [SerializeField] private BlockInfo _blockInfo;
        [Range(0f, 1f)]
        [SerializeField] private float _spawnInPackageProbability;
        [Range(0f, 1f)]
        [SerializeField] private float _spawnCountInPackagePercentage;

        public BlockInfo BlockInfo => _blockInfo;
        public float SpawnInPackageProbability => _spawnInPackageProbability;
        public float SpawnCountInPackagePercentage => _spawnCountInPackagePercentage;
    }
}