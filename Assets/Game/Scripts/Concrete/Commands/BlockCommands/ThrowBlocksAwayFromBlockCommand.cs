using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.ViewCommands.Models;
using Entities.Base;
using Systems.Blocks;

namespace Concrete.Commands.ViewCommands
{
    public class ThrowBlocksAwayFromBlockCommand : ICuttableBlockOnDestroyCommand
    {
        private readonly BlocksSystem _blocksSystem;
        
        
        //Исправить
        private readonly int BaseMultiplier = 10;

        public ThrowBlocksAwayFromBlockCommand(BlocksSystem blocksSystem)
        {
            _blocksSystem = blocksSystem;
        }
        
        public void OnDestroy(CuttableBlock entity, BlockDestroyContext destroyContext)
        {
            var destroyingBlockPosition = entity.transform.position;
            
            foreach (var block in _blocksSystem.AllBlocksOnField)
            {
                var direction = block.transform.position - destroyingBlockPosition;
                var magnitude = BaseMultiplier / direction.magnitude;
                block.AddSpeed(direction.normalized * magnitude);
            }
        }
    }
}