using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.BlockCommands.Models;
using Entities.Base;
using Systems.Blocks;
using UnityEngine;

namespace Concrete.Commands.BlockCommands
{
    public class ThrowBlocksAwayFromBlockCommand : IBlockOnDestroyCommand
    {
        private readonly BlocksSystem _blocksSystem;
        private readonly ExplosionParameters _explosionParameters;

        public ThrowBlocksAwayFromBlockCommand(BlocksSystem blocksSystem, ExplosionParameters explosionParameters)
        {
            _blocksSystem = blocksSystem;
            _explosionParameters = explosionParameters;
        }
        
        public void OnDestroy(Block entity, BlockDestroyContext destroyContext)
        {
            var destroyingBlockPosition = entity.transform.position;
            
            foreach (var block in _blocksSystem.AllBlocksOnField)
            {
                var direction = block.transform.position - destroyingBlockPosition;
                var colliderPoint = direction.magnitude;
                var radius = _explosionParameters.ExplosionRadius;
                if (colliderPoint <= radius)
                {
                    var newExplosionSpeed = (radius - colliderPoint) / radius * _explosionParameters.ExplosionPower;
                    var xSpeed = direction.x * newExplosionSpeed;
                    var ySpeed = direction.y * newExplosionSpeed;
                    block.AddSpeed(new Vector3(xSpeed, ySpeed));
                }
            }
        }
    }

    public class ExplosionParameters
    {
        public ExplosionParameters(float explosionRadius, float explosionPower)
        {
            ExplosionRadius = explosionRadius;
            ExplosionPower = explosionPower;
        }

        public float ExplosionPower { get; }
        public float ExplosionRadius { get; }
    }
}