using System.Collections.Generic;
using Abstracts.Factories;
using Entities.Base;
using UnityEngine;

namespace Concrete.Factories
{
    public class FruitsFactory : IFactory<BlockCreationContext, CuttableBlock>
    {
        private readonly CuttableBlock _prefab;
        private readonly Transform _parent;

        public FruitsFactory(Transform parent,
            CuttableBlock prefab)
        {
            _parent = parent;
            _prefab = prefab;
        }
        
        public CuttableBlock Create(BlockCreationContext creationContext)
        {
            var block = Object.Instantiate(_prefab, _parent);
            block.transform.position = creationContext.Position;
            block.Initialize(creationContext.BlockInfo);
            block.AddSpeed(creationContext.InitialSpeed);
            block.SetGravityAcceleration(creationContext.BlockGravity);
            return block;
        }
    }
}