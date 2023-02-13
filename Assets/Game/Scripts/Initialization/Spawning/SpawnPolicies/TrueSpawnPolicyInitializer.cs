using Abstracts.Initialization;
using Spawning.Spawning.SpawnPolicies;

namespace Initialization.Spawning.SpawnPolicies
{
    public class TrueSpawnPolicyInitializer : InitializerBase<ISpawnPolicy>
    {
        public override ISpawnPolicy Create() => new TrueSpawnPolicy();
    }
}