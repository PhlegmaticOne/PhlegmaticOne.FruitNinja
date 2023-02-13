using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.ViewCommands.Models;
using Entities.Base;
using Systems.Health;

namespace Concrete.Commands.ViewCommands
{
    public class RemoveHeartCommand : ICuttableBlockOnDestroyCommand
    {
        private readonly HealthSystem _healthSystem;

        public RemoveHeartCommand(HealthSystem healthSystem)
        {
            _healthSystem = healthSystem;
        }
        
        public void OnDestroy(CuttableBlock entity, BlockDestroyContext destroyContext)
        {
            _healthSystem.RemoveHeart();
        }
    }
}