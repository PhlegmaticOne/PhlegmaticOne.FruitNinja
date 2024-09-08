﻿using Configurations;
using Configurations.Spawning;

namespace Spawning.Spawning.Difficulty
{
    public class DefaultSpawningDifficulty : ISpawningDifficulty
    {
        private readonly int _maxDifficulty;
        private readonly SpawnSystemConfiguration _spawningSystemInfo;

        public DefaultSpawningDifficulty(int maxDifficulty, SpawnSystemConfiguration spawningSystemInfo)
        {
            _maxDifficulty = maxDifficulty;
            _spawningSystemInfo = spawningSystemInfo;
        }
        
        public DifficultyInfo CalculateDifficultyInfo(int spawnIteration)
        {
            var iteration = spawnIteration > _maxDifficulty ? _maxDifficulty : spawnIteration;
            return new DifficultyInfo
            {
                BlocksGravity = _spawningSystemInfo.InitialBlockGravity,
                BlocksInPackageCount = CalculateBlocksInPackageCount(iteration, _spawningSystemInfo),
                TimeToNextBlockPackage = CalculateTimeToNextPackage(iteration, _spawningSystemInfo),
                DecreaseBlocksInPackageIntervalsBy = 1,
                TotalBonusesSpawnPercentage = 1,
                TotalDebufsSpawnPercentage = 1
            };
        }

        private int CalculateBlocksInPackageCount(int spawnIteration, SpawnSystemConfiguration spawningSystemInfo)
        {
            var stagesCount = spawningSystemInfo.BlocksInPackage.Max - spawningSystemInfo.BlocksInPackage.Min;
            var stage = spawnIteration * stagesCount / _maxDifficulty;
            return spawningSystemInfo.BlocksInPackage.Min + stage;
        }

        private float CalculateTimeToNextPackage(int spawnIteration, SpawnSystemConfiguration spawningSystemInfo)
        {
            var timeInterval = spawningSystemInfo.SpawnPackageIntervals.Max -
                               spawningSystemInfo.SpawnPackageIntervals.Min;
            var stage = spawnIteration * timeInterval / _maxDifficulty;
            return spawningSystemInfo.SpawnPackageIntervals.Max - stage;
        }
    }
}