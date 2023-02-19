using System.Collections.Generic;
using Concrete.Factories.Blocks.Base;
using Concrete.Factories.Blocks.Models;
using Configurations;
using Entities.Base;
using Spawning.Spawning.Commands;

namespace Spawning.Spawning.Spawners
{
    public class AbstractSpawner : IAbstractSpawner
    {
        private readonly IDictionary<BlockInfo, ICuttableBlocksFactory> _factories;
        private readonly IOnDestroyCommandsProvider _onDestroyCommandsProvider;

        public AbstractSpawner(IDictionary<BlockInfo, ICuttableBlocksFactory> factories, 
            IOnDestroyCommandsProvider onDestroyCommandsProvider)
        {
            _factories = factories;
            _onDestroyCommandsProvider = onDestroyCommandsProvider;
        }
        
        public CuttableBlock Spawn(BlockInfo blockInfo, BlockCreationContext blockCreationContext)
        {
            var block = _factories[blockInfo].Create(blockCreationContext);
            block.SetOnDestroyCommand(_onDestroyCommandsProvider.CreateCommand(block.BlockConfiguration));
            return block;
        }
    }
}