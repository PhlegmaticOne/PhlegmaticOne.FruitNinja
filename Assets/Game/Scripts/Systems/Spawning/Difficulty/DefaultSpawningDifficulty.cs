using Configurations;

namespace Spawning.Spawning.Difficulty
{
    public class DefaultSpawningDifficulty : ISpawningDifficulty
    {
        private readonly int _maxDifficulty;
        private readonly int _maxGravityIncrease;
        private readonly SpawningSystemInfo _spawningSystemInfo;

        public DefaultSpawningDifficulty(int maxDifficulty, int maxGravityIncrease, SpawningSystemInfo spawningSystemInfo)
        {
            _maxDifficulty = maxDifficulty;
            _maxGravityIncrease = maxGravityIncrease;
            _spawningSystemInfo = spawningSystemInfo;
        }
        
        public DifficultyInfo CalculateDifficultyInfo(int spawnIteration)
        {
            var iteration = spawnIteration > _maxDifficulty ? _maxDifficulty : spawnIteration;
            return new DifficultyInfo
            {
                BlocksGravity = CalculateBlocksGravity(iteration, _spawningSystemInfo),
                BlocksInPackageCount = CalculateBlocksInPackageCount(iteration, _spawningSystemInfo),
                TimeToNextBlockPackage = CalculateTimeToNextPackage(iteration, _spawningSystemInfo)
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
            return spawningSystemInfo.SpawnPackageIntervals.Max - stage;
        }

        private float CalculateBlocksGravity(int spawnIteration, SpawningSystemInfo spawningSystemInfo) => 
            spawningSystemInfo.InitialBlockGravity + (float)(_maxGravityIncrease * spawnIteration) / _maxDifficulty;
    }
}