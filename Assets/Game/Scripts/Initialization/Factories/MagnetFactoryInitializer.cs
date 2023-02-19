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
using Systems.Magnet;
using UnityEngine;

namespace Initialization.Factories
{
    public class MagnetFactoryInitializer : CuttableBlocksFactoryInitializer
    {
        [SerializeField] private MagnetSystem _magnetSystem;
        [SerializeField] private BlocksSystem _blocksSystem;
        [SerializeField] private Transform _effectsTransform;
        public override void ConfigureCommands(OnDestroyCommandsProvider onDestroyCommandsProvider,
            SpawningSystemInitializer spawningSystemInitializer)
        {
            onDestroyCommandsProvider.On<MagnetConfiguration>(c => new List<ICuttableBlockOnDestroyCommand>
            {
                new SpawnParticleCommand(c.DestroyParticleSystem, _effectsTransform),
                new CutFruitIntoPartsCommand(spawningSystemInitializer.UncuttableBlocksFactory, _blocksSystem),
                new MagnetBlocksToPointCommand(_magnetSystem, c.Duration, c.MagnetForce, c.Radius)
            });
        }
    }
}