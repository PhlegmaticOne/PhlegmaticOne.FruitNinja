using System.Collections.Generic;
using Configurations;

namespace Spawning.Spawning.SpawnPolicies
{
    public class SpawnPoliciesProvider : ISpawnPoliciesProvider
    {
        private readonly IDictionary<BlockInfo, ISpawnPolicy> _spawnPolicies;

        public SpawnPoliciesProvider(IDictionary<BlockInfo, ISpawnPolicy> spawnPolicies) => _spawnPolicies = spawnPolicies;

        public bool CanSpawn(BlockInfo blockInfo) => _spawnPolicies[blockInfo].CanSpawn();
    }
}