using Configurations;

namespace Spawning.Spawning.Difficulty
{
    public class DefaultSpawningDifficulty : ISpawningDifficulty
    {
        private readonly int _maxDifficulty;
        private readonly int _maxGravityIncrease;

        public DefaultSpawningDifficulty(int maxDifficulty, int maxGravityIncrease)
        {
            _maxDifficulty = maxDifficulty;
            _maxGravityIncrease = maxGravityIncrease;
        }
        
        public DifficultyInfo CalculateDifficultyInfo(int spawnIteration, SpawningSystemInfo spawningSystemInfo)
        {
            var iteration = spawnIteration > _maxDifficulty ? _maxDifficulty : spawnIteration;
            return new DifficultyInfo
            {
                BlocksGravity = CalculateBlocksGravity(iteration, spawningSystemInfo),
                BlocksInPackageCount = CalculateBlocksInPackageCount(iteration, spawningSystemInfo),
                TimeToNextBlockPackage = CalculateTimeToNextPackage(iteration, spawningSystemInfo)
            };
        }

        private int CalculateBlocksInPackageCount(int spawnIteration, SpawningSystemInfo spawningSystemInfo)
        {
            var stagesCount = spawningSystemInfo.BlocksInPackage.Max - spawningSystemInfo.BlocksInPackage.Min;
            var stage = spawnIteration * stagesCount / _maxDifficulty;
            return spawningSystemInfo.BlocksInPackage.Min + stage;
        }

        private float CalculateTimeToNextPackage(int spawnIteration, SpawningSystemInfo spawningSystemInfo)
        {
            var timeInterval = spawningSystemInfo.SpawnPackageIntervals.Max -
                               spawningSystemInfo.SpawnPackageIntervals.Min;
            var stage = spawnIteration * timeInterval / _maxDifficulty;
            return spawningSystemInfo.BlocksInPackage.Max - stage;
        }

        private float CalculateBlocksGravity(int spawnIteration, SpawningSystemInfo spawningSystemInfo) => 
            spawningSystemInfo.InitialBlockGravity + (float)(_maxGravityIncrease * spawnIteration) / _maxDifficulty;
    }
}