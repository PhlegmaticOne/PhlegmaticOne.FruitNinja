using System.Collections.Generic;
using Concrete.Factories.Blocks.Base;
using Concrete.Factories.Blocks.Models;
using Configurations;
using Entities.Base;

namespace Spawning.Spawning.Spawners
{
    public class AbstractSpawner : IAbstractSpawner
    {
        private readonly IDictionary<BlockInfo, ICuttableBlocksFactory> _factories;

        public AbstractSpawner(IDictionary<BlockInfo, ICuttableBlocksFactory> factories)
        {
            _factories = factories;
        }
        
        public CuttableBlock Spawn(BlockInfo blockInfo, BlockCreationContext blockCreationContext)
        {
            return _factories[blockInfo].Create(blockCreationContext);
        }
    }
}