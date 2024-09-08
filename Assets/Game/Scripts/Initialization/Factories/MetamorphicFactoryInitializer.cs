using System.Collections.Generic;
using Composite.Initialization;
using Concrete.Commands.BlockCommands.Base;
using Configurations.Blocks;
using Initialization.Factories.Base;
using Spawning.Commands;

namespace Initialization.Factories
{
    public class MetamorphicFactoryInitializer : SpawningBlocksFactoryInitializer
    {
        public override void ConfigureCommands(OnDestroyCommandsProvider onDestroyCommandsProvider,
            SpawningSystemInitializer spawningSystemInitializer)
        {
            onDestroyCommandsProvider.On<MetamorphicBlockConfiguration>(c => new List<IBlockOnDestroyCommand>()
            {
                
            });
        }
    }
}