using System;
using Configurations.Base;
using UnityEngine;

namespace Configurations
{
    [CreateAssetMenu(menuName = "Create spawning system info", order = 0)]
    public class SpawningSystemInfo : ScriptableObject
    {
        [SerializeField] private MinMaxInfo<int> _blocksInPackage;
        [SerializeField] private MinMaxInfo<float> _spawnBlockInPackageIntevals;
        [SerializeField] private MinMaxInfo<float> _spawnPackageIntervals;
        [SerializeField] private float _initialBlockGravity;

        public MinMaxInfo<int> BlocksInPackage => _blocksInPackage;
        public MinMaxInfo<float> SpawnBlockInPackageIntervals => _spawnBlockInPackageIntevals;
        public MinMaxInfo<float> SpawnPackageIntervals => _spawnPackageIntervals;
        public float InitialBlockGravity => _initialBlockGravity;
    }
}