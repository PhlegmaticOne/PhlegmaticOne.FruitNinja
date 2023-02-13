using Abstracts.Initialization;
using Spawning.Spawning;
using Spawning.Spawning.Difficulty;
using Spawning.Spawning.Packages;
using Spawning.Spawning.Spawners;
using UnityEngine;

namespace Composite
{
    public class SpawningSystemInitializer : CompositeInitializer
    {
        [SerializeField] private SpawningSystem _spawningSystem;
        
        [SerializeField] private InitializerBase<ISpawningDifficulty> _difficultyInitializer;
        [SerializeField] private InitializerBase<IAbstractSpawner> _abstractSpawnerInitializer;
        [SerializeField] private InitializerBase<IPackageGenerator> _packageGeneratorInitializer;
        

        public override void Initialize()
        {
            _spawningSystem.Initialize(_difficultyInitializer.Create(),
                _packageGeneratorInitializer.Create(),
                _abstractSpawnerInitializer.Create());
        }
    }
}