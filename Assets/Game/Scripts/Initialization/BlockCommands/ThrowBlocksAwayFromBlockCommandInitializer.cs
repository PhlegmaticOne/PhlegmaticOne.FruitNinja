using Abstracts.Initialization;
using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.ViewCommands;
using Systems.Blocks;
using UnityEngine;

namespace Initialization.BlockCommands
{
    public class ThrowBlocksAwayFromBlockCommandInitializer : InitializerBase<ICuttableBlockOnDestroyCommand>
    {
        [SerializeField] private BlocksSystem _blocksSystem;
        public override ICuttableBlockOnDestroyCommand Create() => 
            new ThrowBlocksAwayFromBlockCommand(_blocksSystem);
    }
}