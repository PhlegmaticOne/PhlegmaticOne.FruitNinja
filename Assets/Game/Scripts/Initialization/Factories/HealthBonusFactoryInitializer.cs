using System.Collections.Generic;
using System.Linq;
using Composite.Initialization;
using Concrete.Commands.BlockCommands;
using Concrete.Commands.BlockCommands.Base;
using Configurations;
using Configurations.Blocks;
using Initialization.Factories.Base;
using Spawning.Commands;
using Spawning.Spawning.SpawnPolicies;
using Systems.Health;
using UnityEngine;

namespace Initialization.Factories
{
    public class HealthBonusFactoryInitializer : SpawningBlocksFactoryInitializer
    {
        [SerializeField] private Transform _effectsTransform;
        [SerializeField] private HealthSystem _healthSystem;
        public override Dictionary<BlockInfo, ISpawnPolicy> CreateSpawnPolicies() =>
            _spawnableBlocks.ToDictionary(x => x,
                x => new HealthBonusSpawnPolicy(_healthSystem) as ISpawnPolicy);

        public override void ConfigureCommands(OnDestroyCommandsProvider onDestroyCommandsProvider,
            SpawningSystemInitializer spawningSystemInitializer)
        {
            onDestroyCommandsProvider.On<HealthBonusConfiguration>(c => new List<IBlockOnDestroyCommand>
            {
                new SpawnParticleCommand(c.OnDestroyParticleSystem, _effectsTransform),
                new AddHeartCommand(_healthSystem, c.HeartsToGive)
            });
        }
    }
}