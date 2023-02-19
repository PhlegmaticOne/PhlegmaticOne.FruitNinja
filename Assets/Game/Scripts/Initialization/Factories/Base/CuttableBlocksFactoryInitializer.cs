using System.Collections.Generic;
using System.Linq;
using Abstracts.Animations;
using Abstracts.Initialization;
using Composite;
using Composite.Initialization;
using Concrete.Factories.Animations;
using Concrete.Factories.Blocks;
using Concrete.Factories.Blocks.Base;
using Configurations;
using Entities.Base;
using Spawning.Commands;
using Spawning.Spawning.SpawnPolicies;
using UnityEngine;

namespace Initialization.Factories.Base
{
    public abstract class CuttableBlocksFactoryInitializer : MonoBehaviour
    {
        [SerializeField] protected List<BlockInfo> _spawnableBlocks;
        [SerializeField] protected List<InitializerBase<ITransformAnimation>> _transformAnimations;
        [SerializeField] protected Transform _blocksTransform;
        [SerializeField] protected CuttableBlock _prefab;
        
        public Dictionary<BlockInfo, ICuttableBlocksFactory> CreateFactories()
        {
            var animationsFactory = new AnimationsFactory(_transformAnimations.Select(x => x.Create()));
            return _spawnableBlocks
                .ToDictionary(x => x, 
                    x => new CuttableBlocksFactory(_blocksTransform, _prefab, animationsFactory) as ICuttableBlocksFactory);
        }

        public virtual Dictionary<BlockInfo, ISpawnPolicy> CreateSpawnPolicies() => 
            _spawnableBlocks.ToDictionary(x => x, x => new TrueSpawnPolicy() as ISpawnPolicy);

        public abstract void ConfigureCommands(OnDestroyCommandsProvider onDestroyCommandsProvider, 
            SpawningSystemInitializer spawningSystemInitializer);
    }
}