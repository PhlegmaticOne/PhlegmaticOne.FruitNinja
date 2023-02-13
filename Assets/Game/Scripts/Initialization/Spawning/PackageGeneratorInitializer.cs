using Abstracts.Initialization;
using Configurations;
using Spawning.Spawning.Packages;
using Spawning.Spawning.SpawnPolicies;
using UnityEngine;

namespace Initialization.Spawning
{
    public class PackageGeneratorInitializer : InitializerBase<IPackageGenerator>
    {
        [SerializeField] private SpawnSystemConfiguration _spawnSystemConfiguration;
        [SerializeField] private InitializerBase<ISpawnPoliciesProvider> _spawnPoliciesInitializer;
        public override IPackageGenerator Create() => 
            new PackageGenerator(_spawnSystemConfiguration, _spawnPoliciesInitializer.Create());
    }
}