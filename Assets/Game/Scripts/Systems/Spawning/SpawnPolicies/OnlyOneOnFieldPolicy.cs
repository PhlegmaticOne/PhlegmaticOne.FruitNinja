using System.Linq;
using Configurations;
using Systems.Blocks;

namespace Spawning.Spawning.SpawnPolicies
{
    public class OnlyOneOnFieldPolicy : ISpawnPolicy
    {
        private readonly BlocksSystem _blocksSystem;
        private readonly BlockInfo _blockInfo;

        public OnlyOneOnFieldPolicy(BlocksSystem blocksSystem, BlockInfo blockInfo)
        {
            _blocksSystem = blocksSystem;
            _blockInfo = blockInfo;
        }
        
        public bool CanSpawn()
        {
            return _blocksSystem.AllBlocksOnField.All(x => x.BlockInfo != _blockInfo);
        }
    }
}