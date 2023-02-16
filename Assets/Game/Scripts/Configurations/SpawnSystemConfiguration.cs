using System;
using System.Collections.Generic;
using Abstracts.Probabilities;
using UnityEngine;

namespace Configurations
{
    [CreateAssetMenu(menuName = "Create spawn configuration", order = 0)]
    public class SpawnSystemConfiguration : ScriptableObject
    {
        [SerializeField] private List<FruitSpawnProbabilityInfo> _fruitsAvailable;
        [SerializeField] private List<ExtraBlockConfiguration> _debufsAvailable;
        [SerializeField] private List<ExtraBlockConfiguration> _bonusesAvailable;
        [SerializeField] private SpawningSystemInfo _spawningSystemInfo;

        public List<FruitSpawnProbabilityInfo> FruitsAvailable => _fruitsAvailable;
        public List<ExtraBlockConfiguration> DebufsAvailable => _debufsAvailable;
        public List<ExtraBlockConfiguration> BonusesAvailable => _bonusesAvailable;
        
        public SpawningSystemInfo SpawningSystemInfo => _spawningSystemInfo;
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