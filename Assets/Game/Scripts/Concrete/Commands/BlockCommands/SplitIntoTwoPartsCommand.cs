using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.BlockCommands.Models;
using Concrete.Factories.Blocks.Base;
using Concrete.Factories.Blocks.Models;
using Entities.Base;
using Systems.Blocks;
using UnityEngine;

namespace Concrete.Commands.BlockCommands
{
    public class SplitIntoTwoPartsCommand : IBlockOnDestroyCommand
    {
        private readonly Sprite _left;
        private readonly Sprite _right;
        private readonly IBlocksFactory<FromBlockBlockCreationContext> _uncuttableBlocksFactory;
        private readonly BlocksSystem _blocksSystem;
        public SplitIntoTwoPartsCommand(Sprite left, Sprite right,
            IBlocksFactory<FromBlockBlockCreationContext> uncuttableBlocksFactory,
            BlocksSystem blocksSystem)
        {
            _left = left;
            _right = right;
            _uncuttableBlocksFactory = uncuttableBlocksFactory;
            _blocksSystem = blocksSystem;
        }
        
        public void OnDestroy(Block entity, BlockDestroyContext destroyContext)
        {
            SpawnBlock(_right, entity, destroyContext, 0);
            SpawnBlock(_left, entity, destroyContext, 180);
        }
        
        private void SpawnBlock(Sprite newSprite, Block original, BlockDestroyContext fruitDestroyContext, float additionalNewBlockAngle)
        {
            var block = _uncuttableBlocksFactory.Create(new FromBlockBlockCreationContext
            {
                OriginalBlock = original,
                BlockNewSprite = newSprite,
                MultiplySpeedBy = CalculateAdditionalSpeed(fruitDestroyContext),
                Offset = GetBlockPartOffsetFromCenter(original, additionalNewBlockAngle),
                Direction = GetDirectionBasedOnSlicingVectorAngleToXAxis(fruitDestroyContext.SlicingVector),
                Scale = 0.8f
            });
            _blocksSystem.AddBlock(block);
        }

        private static int GetDirectionBasedOnSlicingVectorAngleToXAxis(Vector2 slicingVector)
        {
            var angle = Vector3.Angle(slicingVector, Vector3.right);
            return angle >= 90 ? 1 : -1;
        }

        private static Vector2 GetBlockPartOffsetFromCenter(Block original, float additionalNewBlockAngle)
        {
            var originalTransform = original.transform;
            var halfRadius = originalTransform.localScale.x * original.BlockInfo.Radius / 2;
            var zRotation = (originalTransform.rotation.eulerAngles.z + additionalNewBlockAngle) * Mathf.Deg2Rad;
            var dx = halfRadius * Mathf.Cos(zRotation);
            var dy = halfRadius * Mathf.Sin(zRotation);
            return new Vector2(dx, dy);
        }

        private Vector2 CalculateAdditionalSpeed(BlockDestroyContext blockDestroyContext) => 
            blockDestroyContext.SlicingVector.normalized;
    }
}