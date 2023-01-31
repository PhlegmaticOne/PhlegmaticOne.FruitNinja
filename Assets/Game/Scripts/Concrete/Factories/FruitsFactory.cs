using Abstracts.Factories;
using Entities.Base;
using Physics;
using UnityEngine;

namespace Concrete.Factories
{
    public class FruitsFactory : IFactory<BlockCreationContext, CuttableBlock>
    {
        private readonly CuttableBlock _prefab;
        private readonly Transform _parent;
        private readonly MovementBase _movementBase;

        public FruitsFactory(Transform parent, CuttableBlock prefab, MovementBase movementBase)
        {
            _parent = parent;
            _prefab = prefab;
            _movementBase = movementBase;
        }
        
        public CuttableBlock Create(BlockCreationContext creationContext)
        {
            var block = Object.Instantiate(_prefab, _parent);
            block.transform.position = creationContext.Position;
            block.Initialize(_movementBase, creationContext.BlockInfo);
            block.AddSpeed(creationContext.InitialSpeed);
            block.SetGravityAcceleration(creationContext.BlockGravity);
            return block;
        }
    }
}