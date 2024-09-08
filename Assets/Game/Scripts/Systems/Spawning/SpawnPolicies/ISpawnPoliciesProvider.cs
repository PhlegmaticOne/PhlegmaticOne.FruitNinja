using Configurations;

namespace Spawning.Spawning.SpawnPolicies
{
    public interface ISpawnPoliciesProvider
    {
        bool CanSpawn(BlockInfo blockInfo);
    }
}