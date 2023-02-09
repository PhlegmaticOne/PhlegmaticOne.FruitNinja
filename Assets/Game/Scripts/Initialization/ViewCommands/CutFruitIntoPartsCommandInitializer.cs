using Abstracts.Initialization;
using Concrete.Commands.ViewCommands;
using Concrete.Commands.ViewCommands.Base;
using Concrete.Factories.Blocks.Base;
using Systems.Blocks;
using UnityEngine;

namespace Initialization.ViewCommands
{
    public class CutFruitIntoPartsCommandInitializer : InitializerBase<ICuttableBlockOnDestroyViewCommand>
    {
        [SerializeField] private BlocksSystem _blocksSystem;
        [SerializeField] private InitializerBase<IUncuttableBlocksFactory> _uncuttableBlocksFatoryInitializer;
        public override ICuttableBlockOnDestroyViewCommand Create() => 
            new CutFruitIntoPartViewCommand(_uncuttableBlocksFatoryInitializer.Create(), _blocksSystem);
    }
}