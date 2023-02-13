using Abstracts.Initialization;
using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.ViewCommands;
using Concrete.Factories.Blocks.Base;
using Systems.Blocks;
using UnityEngine;

namespace Initialization.BlockCommands
{
    public class CutFruitIntoPartsCommandInitializer : InitializerBase<ICuttableBlockOnDestroyCommand>
    {
        [SerializeField] private BlocksSystem _blocksSystem;
        [SerializeField] private InitializerBase<IUncuttableBlocksFactory> _uncuttableBlocksFatoryInitializer;
        public override ICuttableBlockOnDestroyCommand Create() => 
            new CutFruitIntoPartViewCommand(_uncuttableBlocksFatoryInitializer.Create(), _blocksSystem);
    }
}