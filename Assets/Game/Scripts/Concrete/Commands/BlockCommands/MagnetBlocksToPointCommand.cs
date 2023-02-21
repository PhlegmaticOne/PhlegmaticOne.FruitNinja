using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.BlockCommands.Models;
using Entities.Base;
using Systems.Magnet;

namespace Concrete.Commands.BlockCommands
{
    public class MagnetBlocksToPointCommand : IBlockOnDestroyCommand
    {
        private readonly MagnetSystem _magnetSystem;
        private readonly float _duration;
        private readonly float _power;
        private readonly float _radius;
        private readonly float _magnetizedCenterRadius;

        public MagnetBlocksToPointCommand(MagnetSystem magnetSystem, float duration, 
            float power, float radius, float magnetizedCenterRadius)
        {
            _magnetSystem = magnetSystem;
            _duration = duration;
            _power = power;
            _radius = radius;
            _magnetizedCenterRadius = magnetizedCenterRadius;
        }
        public void OnDestroy(Block entity, BlockDestroyContext destroyContext)
        {
            _magnetSystem.Magnetize(entity.transform.position, _duration, _power, _radius, _magnetizedCenterRadius);
        }
    }
}