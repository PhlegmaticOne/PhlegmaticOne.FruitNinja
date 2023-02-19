using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.BlockCommands.Models;
using Entities.Base;
using Systems.Freezing;

namespace Concrete.Commands.BlockCommands
{
    public class FreezeBlocksCommand : ICuttableBlockOnDestroyCommand
    {
        private readonly FreezingSystem _freezingSystem;
        private readonly float _time;
        private readonly float _acceleration;

        public FreezeBlocksCommand(FreezingSystem freezingSystem, float time, float acceleration)
        {
            _freezingSystem = freezingSystem;
            _time = time;
            _acceleration = acceleration;
        }
        
        public void OnDestroy(CuttableBlock entity, BlockDestroyContext destroyContext)
        {
            _freezingSystem.FreezeBlocks(_time, _acceleration);
        }
    }
}