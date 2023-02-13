using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.ViewCommands.Models;
using Entities.Base;
using Systems.Health;

namespace Concrete.Commands.BlockCommands
{
    public class AddHeartCommand : ICuttableBlockOnDestroyCommand
    {
        private readonly HealthSystem _healthSystem;

        public AddHeartCommand(HealthSystem healthSystem) => _healthSystem = healthSystem;

        public void OnDestroy(CuttableBlock entity, BlockDestroyContext destroyContext) => _healthSystem.AddHeart();
    }
}