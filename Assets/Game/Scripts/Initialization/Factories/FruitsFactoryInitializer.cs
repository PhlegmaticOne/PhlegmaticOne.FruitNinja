using System.Collections.Generic;
using Abstracts.Initialization;
using Composite.Initialization;
using Concrete.Commands.BlockCommands;
using Concrete.Commands.BlockCommands.Base;
using Concrete.Factories.Blocks.Base;
using Configurations.Blocks;
using Helpers;
using Initialization.Factories.Base;
using Spawning.Commands;
using Systems.Blocks;
using Systems.Combos;
using Systems.Combos.Handling;
using Systems.Score;
using UnityEngine;

namespace Initialization.Factories
{
    public class FruitsFactoryInitializer : SpawningBlocksFactoryInitializer
    {
        [SerializeField] private InitializerBase<IComboScoreHandlingPolicy> _comboScoreHandlingPolicyInitializer;
        [SerializeField] private BlocksSystem _blocksSystem;
        [SerializeField] private Transform _effectsTransform;
        [SerializeField] private Transform _uiTransform;
        [SerializeField] private ComboSystem _comboSystem;
        [SerializeField] private ScoreSystem _scoreSystem;
        [SerializeField] private TemporaryTextMeshPro _temporaryTextMeshPro;
        
        public override void ConfigureCommands(OnDestroyCommandsProvider onDestroyCommandsProvider,
            SpawningSystemInitializer spawningSystemInitializer)
        {
            var comboScoreHandlingPolicy = _comboScoreHandlingPolicyInitializer.Create();
            
            onDestroyCommandsProvider.On<FruitBlockConfiguration>(c => new List<IBlockOnDestroyCommand>
            {
                new CutFruitIntoPartsCommand(spawningSystemInitializer.UncuttableBlocksFactory, _blocksSystem),
                new SpawnParticleCommand(c.JuiceParticleSystem, _effectsTransform),
                new SpawnParticleCommand(c.JuiceDropsParticleSystem, _effectsTransform),
                new ScoreHandlingCommand(comboScoreHandlingPolicy, _comboSystem, _scoreSystem, _temporaryTextMeshPro, _uiTransform),
            });
        }
    }
}