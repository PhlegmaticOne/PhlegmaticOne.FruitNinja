using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.BlockCommands.Models;
using Entities.Base;
using Systems.Health;

namespace Concrete.Commands.BlockCommands
{
    public class AddHeartCommand : ICuttableBlockOnDestroyCommand
    {
        private readonly HealthSystem _healthSystem;
        private readonly int _heartsToGive;

        public AddHeartCommand(HealthSystem healthSystem, int heartsToGive)
        {
            _healthSystem = healthSystem;
            _heartsToGive = heartsToGive;
        }

        public void OnDestroy(CuttableBlock entity, BlockDestroyContext destroyContext)
        {
            for (var i = 0; i < _heartsToGive; i++)
            {
                _healthSystem.AddHeart(entity.transform.position);
            }
        }
    }
}