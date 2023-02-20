using Abstracts.Animations;
using Concrete.Animations;
using Concrete.Factories.Blocks.Base;
using Concrete.Factories.Blocks.Models;
using Configurations;
using DG.Tweening;
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

            block.transform.position = (Vector2)transform.position + creationContext.Offset;
            block.transform.rotation = transform.rotation;
            block.transform.localScale = transform.localScale * creationContext.Scale;
            block.SetGravityAcceleration(originalBlock.GetGravityAcceleration());
            block.AddSpeed((Vector2)originalBlock.GetSpeed() + creationContext.MultiplySpeedBy);
            blockInfo.SetSprite(creationContext.BlockNewSprite);
            blockInfo.SetMagnetBehaviour(originalBlock.BlockInfo.MagnetBehaviour);
            block.Initialize(blockInfo, new PrivateRotateAnimation(6, creationContext.Direction));

            return block;
        }
        
        private class PrivateRotateAnimation : ITransformAnimation
        {
            private readonly float _duration;
            private readonly int _direction;
            private static readonly Vector3 FullCircle = new Vector3(0, 0, 360);
        
            public PrivateRotateAnimation(float duration, int direction)
            {
                _duration = duration;
                _direction = direction;
            }
        
            public void Start(Transform transform)
            {
                transform
                    .DORotate(FullCircle * _direction, _duration, RotateMode.FastBeyond360)
                    .SetLoops(-1, LoopType.Restart)
                    .SetEase(Ease.Linear);
            }

            public void Stop(Transform transform) => transform.DOKill();
        }
    }
}