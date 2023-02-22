using System.Collections.Generic;
using Composite.Initialization;
using Concrete.Commands.BlockCommands;
using Concrete.Commands.BlockCommands.Base;
using Configurations.Blocks;
using Initialization.Factories.Base;
using Spawning.Commands;
using UnityEngine;

namespace Initialization.Factories
{
    public class BrickFactoryInitializer : SpawningBlocksFactoryInitializer
    {
        [SerializeField] private Transform _effectsTransform;
        public override void ConfigureCommands(OnDestroyCommandsProvider onDestroyCommandsProvider,
            SpawningSystemInitializer spawningSystemInitializer)
        {
            onDestroyCommandsProvider.On<BrickBlockConfiguration>(c => new List<IBlockOnDestroyCommand>
            {
                new SpawnParticleCommand(c.OnCollisionParticleSystem, _effectsTransform),
                new DisableInputCommand(spawningSystemInitializer.InputSystem, c.BlocksInput),
            });
        }
    }
}