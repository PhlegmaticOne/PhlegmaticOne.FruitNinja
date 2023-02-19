using System.Collections.Generic;
using Abstracts.Initialization;
using Composite.Initialization;
using Concrete.Commands.BlockCommands;
using Concrete.Commands.BlockCommands.Base;
using Configurations.Blocks;
using Initialization.Factories.Base;
using Spawning.Commands;
using Systems.Follow;
using UnityEngine;

namespace Initialization.Factories
{
    public class BrickFactoryInitializer : CuttableBlocksFactoryInitializer
    {
        [SerializeField] private FollowSystem _followSystem;
        public override void ConfigureCommands(OnDestroyCommandsProvider onDestroyCommandsProvider,
            SpawningSystemInitializer spawningSystemInitializer)
        {
            onDestroyCommandsProvider.On<BrickBlockConfiguration>(c => new List<ICuttableBlockOnDestroyCommand>
            {
                new DisableInputCommand(spawningSystemInitializer.InputSystem, c.BlocksInput),
                new FollowInputCommand(_followSystem, spawningSystemInitializer.AbstractSpawner)
            });
        }
    }
}