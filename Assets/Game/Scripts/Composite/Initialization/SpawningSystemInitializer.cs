using System.Collections.Generic;
using Abstracts.Initialization;
using Composite.Base;
using Concrete.Factories.Blocks.Base;
using Configurations;
using Configurations.Spawning;
using Initialization.Factories.Base;
using InputSystem;
using Spawning.Commands;
using Spawning.Spawning;
using Spawning.Spawning.Difficulty;
using Spawning.Spawning.Packages;
using Spawning.Spawning.Spawners;
using Spawning.Spawning.SpawnPolicies;
using UnityEngine;

namespace Composite.Initialization
{
    public class SpawningSystemInitializer : CompositeInitializer
    {
        [SerializeField] private SpawningSystem _spawningSystem;

        [SerializeField] private SpawnSystemConfiguration _spawnSystemConfiguration;
        [SerializeField] private DifficultyConfiguration _difficultyConfiguration;
        [SerializeField] private InitializerBase<IUncuttableBlocksFactory> _uncuttableBlocksFactoryInitializer;
        [SerializeField] private InitializerBase<IInputSystemFactory> _inputSystemFactoryInitialzer;
        [SerializeField] private List<CuttableBlocksFactoryInitializer> _factoryInitializers;

        internal IAbstractSpawner AbstractSpawner;
        internal IInputSystem InputSystem;
        internal IUncuttableBlocksFactory UncuttableBlocksFactory;
        internal ISpawnPoliciesProvider SpawnPoliciesProvider;
        internal IPackageGenerator PackageGenerator;
        internal ISpawningDifficulty SpawningDifficulty;
        
        public override void Initialize()
        {
            Configure();
            _spawningSystem.Initialize(SpawningDifficulty, PackageGenerator, AbstractSpawner);
        }

        private void Configure()
        {
            var commandsProvider = new OnDestroyCommandsProvider();
            var factories = new Dictionary<BlockInfo, ICuttableBlocksFactory>();
            var spawnPolicies = new Dictionary<BlockInfo, ISpawnPolicy>();
            
            foreach (var factoryInitializer in _factoryInitializers)
            {
                foreach (var blocksFactory in factoryInitializer.CreateFactories())
                {
                    factories.Add(blocksFactory.Key, blocksFactory.Value);
                }

                foreach (var spawnPolicy in factoryInitializer.CreateSpawnPolicies())
                {
                    spawnPolicies.Add(spawnPolicy.Key, spawnPolicy.Value);
                }
                
                factoryInitializer.ConfigureCommands(commandsProvider, this);
            }

            InputSystem = _inputSystemFactoryInitialzer.Create().CreateInput();
            UncuttableBlocksFactory = _uncuttableBlocksFactoryInitializer.Create();
            AbstractSpawner = new AbstractSpawner(factories, commandsProvider);
            SpawnPoliciesProvider = new SpawnPoliciesProvider(spawnPolicies);
            PackageGenerator = new PackageGenerator(_spawnSystemConfiguration, SpawnPoliciesProvider);
            SpawningDifficulty = new DefaultSpawningDifficulty(_difficultyConfiguration.MaxDifficulty, _spawnSystemConfiguration);
        }
    }
}