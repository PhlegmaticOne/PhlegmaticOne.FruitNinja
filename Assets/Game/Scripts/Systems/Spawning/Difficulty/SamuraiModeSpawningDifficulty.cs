using Configurations.Spawning;
using UnityEngine;

namespace Spawning.Spawning.Difficulty
{
    public class SamuraiModeSpawningDifficulty : ISpawningDifficulty
    {
        private readonly SpawnSystemConfiguration _spawnSystemConfiguration;
        private readonly float _increaseBlocksCountInPackageBy;
        private readonly float _decreasePackageIntervalsBy;

        public SamuraiModeSpawningDifficulty(SpawnSystemConfiguration spawnSystemConfiguration,
            float increaseBlocksCountInPackageBy,
            float decreasePackageIntervalsBy)
        {
            _spawnSystemConfiguration = spawnSystemConfiguration;
            _increaseBlocksCountInPackageBy = increaseBlocksCountInPackageBy;
            _decreasePackageIntervalsBy = decreasePackageIntervalsBy;
        }
        
        public DifficultyInfo CalculateDifficultyInfo(int spawnIteration)
        {
            return new DifficultyInfo
            {
                BlocksGravity = CalculateBlocksGravity(_spawnSystemConfiguration),
                BlocksInPackageCount = CalculateBlocksInPackageCount(),
                TimeToNextBlockPackage = CalculateTimeToNextPackage(_spawnSystemConfiguration),
                DecreaseBlocksInPackageIntervalsBy = _decreasePackageIntervalsBy,
                TotalBonusesSpawnPercentage = 0,
                TotalDebufsSpawnPercentage = 0
            };
        }
        
        private int CalculateBlocksInPackageCount()
        {
            var blocksInPackage = _spawnSystemConfiguration.BlocksInPackage;
            return Random.Range(blocksInPackage.Min, blocksInPackage.Max + 1) * (int)_increaseBlocksCountInPackageBy;
        }

        private float CalculateTimeToNextPackage(SpawnSystemConfiguration spawningSystemInfo)
        {
            var spawnPackageIntervals = spawningSystemInfo.SpawnPackageIntervals;
            return Random.Range(spawnPackageIntervals.Min, spawnPackageIntervals.Max) / _decreasePackageIntervalsBy;
        }

        private float CalculateBlocksGravity(SpawnSystemConfiguration spawningSystemInfo) => 
            spawningSystemInfo.InitialBlockGravity;
    }
}