using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.BlockCommands.Models;
using Entities.Base;
using Systems.Health;

namespace Concrete.Commands.BlockCommands
{
    public class RemoveHeartCommand : ICuttableBlockOnDestroyCommand
    {
        private readonly HealthSystem _healthSystem;
        private readonly int _heartsCount;

        public RemoveHeartCommand(HealthSystem healthSystem, int heartsCount)
        {
            _healthSystem = healthSystem;
            _heartsCount = heartsCount;
        }
        
        public void OnDestroy(CuttableBlock entity, BlockDestroyContext destroyContext)
        {
            for (var i = 0; i < _heartsCount; i++)
            {
                _healthSystem.RemoveHeart();
            }
        }
    }
}