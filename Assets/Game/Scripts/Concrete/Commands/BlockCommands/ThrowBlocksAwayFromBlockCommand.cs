using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.ViewCommands.Models;
using Entities.Base;
using Initialization.BlockCommands;
using Systems.Blocks;
using UnityEngine;

namespace Concrete.Commands.ViewCommands
{
    public class ThrowBlocksAwayFromBlockCommand : ICuttableBlockOnDestroyCommand
    {
        private readonly BlocksSystem _blocksSystem;
        private readonly ExplosionParameters _explosionParameters;

        public ThrowBlocksAwayFromBlockCommand(BlocksSystem blocksSystem, ExplosionParameters explosionParameters)
        {
            _blocksSystem = blocksSystem;
            _explosionParameters = explosionParameters;
        }
        
        public void OnDestroy(CuttableBlock entity, BlockDestroyContext destroyContext)
        {
            var destroyingBlockPosition = entity.transform.position;
            
            foreach (var block in _blocksSystem.AllBlocksOnField)
            {
                var direction = block.transform.position - destroyingBlockPosition;
                float colliderPoint = direction.magnitude;
                var radius = _explosionParameters.ExplosionRadius;
                if (colliderPoint <= radius)
                {
                    float newExplosionSpeed = (radius - colliderPoint) / radius * _explosionParameters.ExplosionPower;
                    float xSpeed = (direction.x) * newExplosionSpeed;
                    float ySpeed = (direction.y) * newExplosionSpeed;
                    block.AddSpeed(new Vector3(xSpeed, ySpeed));
                }
            }
        }

        private Vector3 GetSpeed(Vector3 from, Vector3 to)
        {
            var direction = from - to;
            var radius = _explosionParameters.ExplosionRadius;
            var newExplosionSpeed = (radius - direction.magnitude) / radius * _explosionParameters.ExplosionPower;
            
            float xSpeed = (direction.x) * newExplosionSpeed;
            float ySpeed = (direction.y) * newExplosionSpeed;
            return new Vector3(xSpeed, ySpeed);
        }
    }
}