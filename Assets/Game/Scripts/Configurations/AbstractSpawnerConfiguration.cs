using System;
using System.Collections.Generic;
using System.Linq;
using Abstracts.Initialization;
using Concrete.Factories.Blocks.Base;
using UnityEngine;

namespace Configurations
{
    public class AbstractSpawnerConfiguration : MonoBehaviour
    {
        [SerializeField] private List<AbstractSpawnerInfo> _spawnPolicyInfos;

        public IDictionary<BlockInfo, ICuttableBlocksFactory> BuildBlockFactories()
        {
            return _spawnPolicyInfos.ToDictionary(x => x.BlockInfo, x => x.FactoryInitializer.Create());
        }
    }

    [Serializable]
    public class AbstractSpawnerInfo
    {
        [SerializeField] private BlockInfo _blockInfo;
        [SerializeField] private InitializerBase<ICuttableBlocksFactory> _factoryInitializer;

        public BlockInfo BlockInfo => _blockInfo;
        public InitializerBase<ICuttableBlocksFactory> FactoryInitializer => _factoryInitializer;
    }
}