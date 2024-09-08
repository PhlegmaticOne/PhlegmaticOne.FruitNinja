using System.Collections.Generic;
using System.Linq;
using Composite.Initialization;
using Concrete.Commands.BlockCommands;
using Concrete.Commands.BlockCommands.Base;
using Configurations;
using Configurations.Blocks;
using Configurations.Spawning;
using Helpers;
using Initialization.Factories.Base;
using Spawning.Commands;
using Spawning.Spawning;
using Spawning.Spawning.SpawnPolicies;
using Systems.Blocks;
using Systems.Health;
using Systems.Samurai;
using UnityEngine;

namespace Initialization.Factories
{
    public class SamuraiBonusFactoryInitializer : SpawningBlocksFactoryInitializer
    {
        [SerializeField] private HealthController _healthController;
        [SerializeField] private SpawningSystem _spawningSystem;
        [SerializeField] private SpawnSystemConfiguration _spawnSystemConfiguration;
        [SerializeField] private SamuraiCanvas _samuraiCanvas;
        [SerializeField] private Timer _timer;
        [SerializeField] private BlocksSystem _blocksSystem;
        [SerializeField] private Transform _effectsTransform;
        [SerializeField] private BlockInfo _blockInfo;

        public override Dictionary<BlockInfo, ISpawnPolicy> CreateSpawnPolicies()
        {
            return _spawnableBlocks.ToDictionary(x => x,
                x => new OnlyOneOnFieldPolicy(_blocksSystem, _blockInfo) as ISpawnPolicy);
        }

        public override void ConfigureCommands(OnDestroyCommandsProvider onDestroyCommandsProvider,
            SpawningSystemInitializer spawningSystemInitializer)
        {
            onDestroyCommandsProvider.On<SamuraiBonusConfiguration>(c => new List<IBlockOnDestroyCommand>
            {
                new CutFruitIntoPartsCommand(spawningSystemInitializer.UncuttableBlocksFactory, _blocksSystem),
                new SpawnParticleCommand(c.OnDestroyParticleSystem, _effectsTransform),
                new StartTimerCommand(_timer, c.Duration),
                new EnableSamuraiModeCommand(_spawningSystem, _healthController, 
                    _samuraiCanvas, _spawnSystemConfiguration,
                    c.Duration, c.IncreaseBlocksCountInPackageBy, c.DecreasePackageIntervalsBy)
            });
        }
    }
}