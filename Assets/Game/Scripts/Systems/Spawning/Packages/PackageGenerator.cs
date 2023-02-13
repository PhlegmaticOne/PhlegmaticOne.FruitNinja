using System.Collections.Generic;
using Abstracts.Extensions;
using Configurations;
using Spawning.Spawning.Difficulty;
using Spawning.Spawning.SpawnPolicies;
using UnityEngine;

namespace Spawning.Spawning.Packages
{
    public class PackageGenerator : IPackageGenerator
    {
        private readonly SpawnSystemConfiguration _spawnSystemConfiguration;
        private readonly ISpawnPoliciesProvider _spawnPoliciesProvider;
        private readonly SpawningSystemInfo _spawningSystemInfo;

        public PackageGenerator(SpawnSystemConfiguration spawnSystemConfiguration, 
            ISpawnPoliciesProvider spawnPoliciesProvider)
        {
            _spawnSystemConfiguration = spawnSystemConfiguration;
            _spawnPoliciesProvider = spawnPoliciesProvider;
            _spawningSystemInfo = spawnSystemConfiguration.SpawningSystemInfo;
        }
        
        public BlocksPackage GeneratePackage(DifficultyInfo difficultyInfo)
        {
            var result = new List<PackageEntry>();
            var blocksInPackage = difficultyInfo.BlocksInPackageCount;
            
            TryAddExtraBlocks(result, blocksInPackage, _spawnSystemConfiguration.DebufsAvailable);
            TryAddExtraBlocks(result, blocksInPackage, _spawnSystemConfiguration.BonusesAvailable);

            while (result.Count <  blocksInPackage)
            {
                result.Add(new PackageEntry
                {
                    BlockInfo = GetRandomFruit(),
                    TimeToNextBlock = GetRandomTimeToNextBlock()
                });
            }
            
            return new BlocksPackage(result.Shuffle());
        }

        private BlockInfo GetRandomFruit()
        {
            var rnd = Random.Range(0, _spawnSystemConfiguration.FruitsAvailable.Count);
            return _spawnSystemConfiguration.FruitsAvailable[rnd];
        }

        private void TryAddExtraBlocks(List<PackageEntry> blocksPackage, int blocksInPackage,
            List<ExtraBlockConfiguration> blockConfigurations)
        {
            foreach (var extraBlockInfo in blockConfigurations)
            {
                var blockInfo = extraBlockInfo.BlockInfo;
                
                if (ProbabilityMatches(extraBlockInfo.SpawnInPackageProbability) ||
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
                        TimeToNextBlock = GetRandomTimeToNextBlock()
                    });
                    randomBlocksCount--;
                }
            }
        }

        private int GetRandomBlocksCountFromPercentage(float percentage, int blocksCount)
        {
            var maxCount = (int)Mathf.Floor(blocksCount * percentage);
            return Random.Range(0, maxCount + 1);
        }

        private float GetRandomTimeToNextBlock()
        {
            return Random.Range(
                _spawningSystemInfo.SpawnBlockInPackageIntervals.Min,
                _spawningSystemInfo.SpawnBlockInPackageIntervals.Max);
        }

        private bool ProbabilityMatches(float probability) => Random.value >= probability;
    }
}