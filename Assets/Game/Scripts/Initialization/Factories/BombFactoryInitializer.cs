using System.Collections.Generic;
using Composite.Initialization;
using Concrete.Commands.BlockCommands;
using Concrete.Commands.BlockCommands.Base;
using Configurations.Blocks;
using Helpers;
using Initialization.Factories.Base;
using Spawning.Commands;
using Systems.Blocks;
using Systems.Health;
using UnityEngine;

namespace Initialization.Factories
{
    public class BombFactoryInitializer : SpawningBlocksFactoryInitializer
    {
        [SerializeField] private Transform _effectsTransform;
        [SerializeField] private Transform _uiTransform;
        [SerializeField] private BlocksSystem _blocksSystem;
        [SerializeField] private TemporaryTextMeshPro _temporaryTextMeshPro;
        [SerializeField] private HealthSystem _healthSystem;
        
        public override void ConfigureCommands(OnDestroyCommandsProvider onDestroyCommandsProvider,
            SpawningSystemInitializer spawningSystemInitializer)
        {
            onDestroyCommandsProvider.On<BombConfiguration>(c => new List<IBlockOnDestroyCommand>
            {
                new SpawnParticleCommand(c.ExplosionParticle, _effectsTransform),
                new SpawnTemporaryTextCommand(c.OnExplosionText, _temporaryTextMeshPro, _uiTransform),
                new ThrowBlocksAwayFromBlockCommand(_blocksSystem, new ExplosionParameters(c.ExplosionRadius, c.ExplosionPower)),
                new RemoveHeartCommand(_healthSystem, c.HeartsToRemove),
            });
        }
    }
}