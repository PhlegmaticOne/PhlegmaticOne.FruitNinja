using Abstracts.Initialization;
using Concrete.Factories.Blocks;
using Concrete.Factories.Blocks.Base;
using Entities.Base;
using UnityEngine;

namespace Initialization.Factories
{
    public class UncuttableBlocksFactoryInitializer : InitializerBase<IUncuttableBlocksFactory>
    {
        [SerializeField] private UncuttableBlock _prefab;
        [SerializeField] private Transform _blocksTransform;
        public override IUncuttableBlocksFactory Create() => new UncuttableBlockFactory(_prefab, _blocksTransform);
    }
}