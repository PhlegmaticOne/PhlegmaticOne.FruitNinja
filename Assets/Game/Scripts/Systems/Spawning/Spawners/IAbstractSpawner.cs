using Concrete.Factories.Blocks.Models;
using Configurations;
using Entities.Base;

namespace Spawning.Spawning.Spawners
{
    public interface IAbstractSpawner
    {
        CuttableBlock Spawn(BlockInfo blockInfo, BlockCreationContext blockCreationContext);
    }
}