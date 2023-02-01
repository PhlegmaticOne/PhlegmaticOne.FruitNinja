using System;
using Configurations.Base;
using UnityEngine;

namespace Configurations
{
    [Serializable]
    public class SpawningSystemInfo
    {
        [SerializeField] private MinMaxInfo<int> _blocksInPackage;
        [SerializeField] private MinMaxInfo<float> _spawnBlockInPackageIntevals;
        [SerializeField] private MinMaxInfo<float> _spawnPackageIntervals;

        public MinMaxInfo<int> BlocksInPackage => _blocksInPackage;
        public MinMaxInfo<float> SpawnBlockInPackageIntervals => _spawnBlockInPackageIntevals;
        public MinMaxInfo<float> SpawnPackageIntervals => _spawnPackageIntervals;
    }
}