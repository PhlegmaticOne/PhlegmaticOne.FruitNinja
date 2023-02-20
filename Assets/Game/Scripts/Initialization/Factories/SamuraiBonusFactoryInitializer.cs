using System.Collections.Generic;
using Composite.Initialization;
using Concrete.Commands.BlockCommands;
using Concrete.Commands.BlockCommands.Base;
using Configurations.Blocks;
using Configurations.Spawning;
using Helpers;
using Initialization.Factories.Base;
using Spawning.Commands;
using Spawning.Spawning;
using Systems.Health;
using Systems.Samurai;
using UnityEngine;

namespace Initialization.Factories
{
    public class SamuraiBonusFactoryInitializer : CuttableBlocksFactoryInitializer
    {
        [SerializeField] private HealthController _healthController;
        [SerializeField] private SpawningSystem _spawningSystem;
        [SerializeField] private SpawnSystemConfiguration _spawnSystemConfiguration;
        [SerializeField] private SamuraiCanvas _samuraiCanvas;
        [SerializeField] private Timer _timer;
        public override void ConfigureCommands(OnDestroyCommandsProvider onDestroyCommandsProvider,
            SpawningSystemInitializer spawningSystemInitializer)
        {
            onDestroyCommandsProvider.On<SamuraiBonusConfiguration>(c => new List<ICuttableBlockOnDestroyCommand>
            {
                new StartTimerCommand(_timer, c.Duration),
                new EnableSamuraiModeCommand(_spawningSystem, _healthController, 
                    _samuraiCanvas, _spawnSystemConfiguration,
                    c.Duration, c.IncreaseBlocksCountInPackageBy, c.DecreasePackageIntervalsBy)
            });
        }
    }
}