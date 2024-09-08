using System;
using System.Collections.Generic;
using Abstracts.Probabilities;
using Configurations.Base;
using UnityEngine;

namespace Configurations.Spawning
{
    [CreateAssetMenu(menuName = "Spawning/Create spawn configuration", order = 0)]
    public class SpawnSystemConfiguration : ScriptableObject
    {
        [SerializeField] private MinMaxInfo<int> _blocksInPackage;
        [SerializeField] private MinMaxInfo<float> _spawnBlockInPackageIntevals;
        [SerializeField] private MinMaxInfo<float> _spawnPackageIntervals;
        [SerializeField] private float _initialBlockGravity;
        
        [SerializeField] private List<FruitSpawnProbabilityInfo> _fruitsAvailable;
        [SerializeField] private List<ExtraBlockConfiguration> _debufsAvailable;
        [SerializeField] private List<ExtraBlockConfiguration> _bonusesAvailable;
        
        public List<FruitSpawnProbabilityInfo> FruitsAvailable => _fruitsAvailable;
        public List<ExtraBlockConfiguration> DebufsAvailable => _debufsAvailable;
        public List<ExtraBlockConfiguration> BonusesAvailable => _bonusesAvailable;
        public MinMaxInfo<int> BlocksInPackage => _blocksInPackage;
        public MinMaxInfo<float> SpawnBlockInPackageIntervals => _spawnBlockInPackageIntevals;
        public MinMaxInfo<float> SpawnPackageIntervals => _spawnPackageIntervals;
        public float InitialBlockGravity => _initialBlockGravity;
    }

    [Serializable]
    public class FruitSpawnProbabilityInfo : IHavePriority
    {
        [SerializeField] private BlockInfo _fruitInfo;
        [SerializeField] private int _priority;

        public BlockInfo FruitInfo => _fruitInfo;
        public float Priority => _priority;
    }
}