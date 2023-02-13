using Abstracts.Initialization;
using Configurations;
using Spawning.Spawning.SpawnPolicies;
using UnityEngine;

namespace Initialization.Spawning
{
    public class SpawnPoliciesProviderInitializer : InitializerBase<ISpawnPoliciesProvider>
    {
        [SerializeField] private SpawnPoliciesConfiguration _spawnPoliciesConfiguration;
        public override ISpawnPoliciesProvider Create() => 
            new SpawnPoliciesProvider(_spawnPoliciesConfiguration.BuildSpawnPolicies());
    }
}