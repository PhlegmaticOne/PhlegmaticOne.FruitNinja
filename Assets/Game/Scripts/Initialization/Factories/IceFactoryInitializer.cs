using System.Collections.Generic;
using Composite.Initialization;
using Concrete.Commands.BlockCommands;
using Concrete.Commands.BlockCommands.Base;
using Configurations.Blocks;
using Initialization.Factories.Base;
using Spawning.Commands;
using Systems.Blocks;
using Systems.Freezing;
using UnityEngine;

namespace Initialization.Factories
{
    public class IceFactoryInitializer : SpawningBlocksFactoryInitializer
    {
        [SerializeField] private FreezingSystem _freezingSystem;
        [SerializeField] private Transform _effectsTransform;
        [SerializeField] private BlocksSystem _blocksSystem;
        public override void ConfigureCommands(OnDestroyCommandsProvider onDestroyCommandsProvider,
            SpawningSystemInitializer spawningSystemInitializer)
        {
            onDestroyCommandsProvider.On<IceBlockConfiguration>(c => new List<IBlockOnDestroyCommand>
            {
                new CutFruitIntoPartsCommand(spawningSystemInitializer.UncuttableBlocksFactory, _blocksSystem),
                new SpawnParticleCommand(c.DestroyParticleSystem, _effectsTransform),
                new FreezeBlocksCommand(_freezingSystem, c.EffectDuration, c.Force)
            });
        }
    }
}