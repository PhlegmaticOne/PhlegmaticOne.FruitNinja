using Abstracts.Initialization;
using Concrete.Factories.Blocks;
using Concrete.Factories.Blocks.Base;
using Concrete.Factories.Blocks.Models;
using Entities.Base;
using UnityEngine;

namespace Initialization.Factories.Base
{
    public class CutBlocksFactoryInitializer : InitializerBase<IBlocksFactory<FromBlockBlockCreationContext>>
    {
        [SerializeField] private Block _prefab;
        [SerializeField] private Transform _blocksTransform;
        public override IBlocksFactory<FromBlockBlockCreationContext> Create() => new CutBlockFactory(_prefab, _blocksTransform);
    }
}