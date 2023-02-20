using System.Collections.Generic;
using Abstracts.Initialization;
using Composite.Initialization;
using Concrete.Commands.BlockCommands;
using Concrete.Commands.BlockCommands.Base;
using Concrete.Factories.Blocks.Base;
using Configurations.Blocks;
using Initialization.Factories.Base;
using Spawning.Commands;
using Systems.Blocks;
using Systems.Cutting;
using UnityEngine;

namespace Initialization.Factories
{
    public class FruitBasketFactoryInitializer : CuttableBlocksFactoryInitializer
    {
        [SerializeField] private BlocksSystem _blocksSystem;
        [SerializeField] private CuttingSystem _cuttingSystem;
        public override void ConfigureCommands(OnDestroyCommandsProvider onDestroyCommandsProvider,
            SpawningSystemInitializer spawningSystemInitializer)
        {
            onDestroyCommandsProvider.On<FruitBasketConfiguration>(c => new List<ICuttableBlockOnDestroyCommand>
            {
                new SplitIntoTwoPartsCommand(c.CutSprites.LeftHalf, c.CutSprites.RightHalf,
                    spawningSystemInitializer.UncuttableBlocksFactory, _blocksSystem),
                
                new SpawnBlocksCommand(c.FruitsAvailable, c.BlocksCountInfo,
                     c.ExplosionPower, c.DelayAfterSlicing,
                     spawningSystemInitializer.AbstractSpawner,
                     _blocksSystem, _cuttingSystem)
            });
        }
    }
}