using System.Collections.Generic;
using Abstracts.Extensions;
using Abstracts.Probabilities;
using Configurations;
using Configurations.Spawning;
using Spawning.Spawning.Difficulty;
using Spawning.Spawning.SpawnPolicies;
using UnityEngine;

namespace Spawning.Spawning.Packages
{
    public class PackageGenerator : IPackageGenerator
    {
        private readonly ISpawnPoliciesProvider _spawnPoliciesProvider;
        private readonly SpawnSystemConfiguration _spawnSystemConfiguration;

        public PackageGenerator(SpawnSystemConfiguration spawnSystemConfiguration, 
            ISpawnPoliciesProvider spawnPoliciesProvider)
        {
            _spawnSystemConfiguration = spawnSystemConfiguration;
            _spawnPoliciesProvider = spawnPoliciesProvider;
        }
        
        public BlocksPackage GeneratePackage(DifficultyInfo difficultyInfo)
        {
            var result = new List<PackageEntry>();

            TryAddExtraBlocks(result, difficultyInfo, difficultyInfo.TotalDebufsSpawnPercentage, _spawnSystemConfiguration.DebufsAvailable);
            TryAddExtraBlocks(result, difficultyInfo, difficultyInfo.TotalBonusesSpawnPercentage, _spawnSystemConfiguration.BonusesAvailable);

            var blocksInPackage = difficultyInfo.BlocksInPackageCount;
            
            while (result.Count <  blocksInPackage)
            {
                result.Add(new PackageEntry
                {
                    BlockInfo = GetRandomFruit(),
                    TimeToNextBlock = GetRandomTimeToNextBlock(difficultyInfo)
                });
            }
            
            return new BlocksPackage(result.Shuffle());
        }

        private BlockInfo GetRandomFruit() => 
            _spawnSystemConfiguration.FruitsAvailable.GetRandomItemBasedOnProbabilities().FruitInfo;

        private void TryAddExtraBlocks(List<PackageEntry> blocksPackage, 
            DifficultyInfo difficultyInfo,
            float totalSpawnPercentage,
            List<ExtraBlockConfiguration> blockConfigurations)
        {
            var blocksInPackage = difficultyInfo.BlocksInPackageCount;
            
            foreach (var extraBlockInfo in blockConfigurations)
            {
                var blockInfo = extraBlockInfo.BlockInfo;

                if (ProbabilityMatches(totalSpawnPercentage) == false)
                {
                    continue;
                }
                
                if (ProbabilityMatches(extraBlockInfo.SpawnInPackageProbability) == false ||
                    _spawnPoliciesProvider.CanSpawn(blockInfo) == false)
                {
                    continue;
                }
                
                var randomBlocksCount =
                    GetRandomBlocksCountFromPercentage(extraBlockInfo.SpawnCountInPackagePercentage, blocksInPackage);

                while (randomBlocksCount > 0 && blocksPackage.Count <=  blocksInPackage)
                {
                    blocksPackage.Add(new PackageEntry
                    {
                        BlockInfo = blockInfo,
                        TimeToNextBlock = GetRandomTimeToNextBlock(difficultyInfo)
                    });
                    randomBlocksCount--;
                }
            }
        }

        private int GetRandomBlocksCountFromPercentage(float percentage, int blocksCount)
        {
            var maxCount = (int)Mathf.Ceil(blocksCount * percentage);
            return Random.Range(0, maxCount + 1);
        }

        private float GetRandomTimeToNextBlock(DifficultyInfo difficultyInfo)
        {
            return Random.Range(
                _spawnSystemConfiguration.SpawnBlockInPackageIntervals.Min,
                _spawnSystemConfiguration.SpawnBlockInPackageIntervals.Max) / difficultyInfo.DecreaseBlocksInPackageIntervalsBy;
        }

        private bool ProbabilityMatches(float probability) => Random.value <= probability;
    }
}