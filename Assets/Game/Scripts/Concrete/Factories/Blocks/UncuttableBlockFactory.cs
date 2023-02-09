using Concrete.Factories.Blocks.Base;
using Concrete.Factories.Blocks.Models;
using Configurations;
using Entities.Base;
using UnityEngine;

namespace Concrete.Factories.Blocks
{
    public class UncuttableBlockFactory : IUncuttableBlocksFactory
    {
        private readonly UncuttableBlock _uncuttableBlockPrefab;
        private readonly Transform _parent;

        public UncuttableBlockFactory(UncuttableBlock uncuttableBlockPrefab, Transform parent)
        {
            _uncuttableBlockPrefab = uncuttableBlockPrefab;
            _parent = parent;
        }
        
        public UncuttableBlock Create(FromBlockBlockCreationContext creationContext)
        {
            var block = Object.Instantiate(_uncuttableBlockPrefab, _parent, true);
            var blockInfo = ScriptableObject.CreateInstance<BlockInfo>();
            var originalBlock = creationContext.OriginalBlock;
            var transform = originalBlock.transform;
            
            block.transform.position = transform.position;
            block.transform.rotation = Quaternion.Euler(0, 0, creationContext.Angle);
            block.transform.localScale = transform.localScale;
            block.SetGravityAcceleration(originalBlock.GetGravityAcceleration());
            block.AddSpeed(originalBlock.GetSpeed() * creationContext.MultiplySpeedBy);
            blockInfo.SetSprite(creationContext.BlockNewSprite);
            block.Initialize(blockInfo, originalBlock.TransformAnimation);

            return block;
        }
    }
}