using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.BlockCommands.Models;
using Concrete.Factories.Blocks.Base;
using Concrete.Factories.Blocks.Models;
using Entities.Base;
using Systems.Blocks;
using UnityEngine;

namespace Concrete.Commands.BlockCommands
{
    public class CutFruitIntoPartsCommand : IBlockOnDestroyCommand
    {
        private readonly IBlocksFactory<FromBlockBlockCreationContext> _uncuttableBlockFactory;
        private readonly BlocksSystem _blocksSystem;

        public CutFruitIntoPartsCommand(IBlocksFactory<FromBlockBlockCreationContext> uncuttableBlockFactory, BlocksSystem blocksSystem)
        {
            _uncuttableBlockFactory = uncuttableBlockFactory;
            _blocksSystem = blocksSystem;
        }
        
        public void OnDestroy(Block entity, BlockDestroyContext destroyContext)
        {
            var blockSprite = entity.BlockInfo.Sprite;
            var texture = blockSprite.texture;
            var xPos = texture.width / 2.0f;
            var rightPivot = (texture.width - xPos) / texture.width;
            var leftPivot = 1.0f - rightPivot;
            
            var leftFruitPart = new Rect(0, 0, xPos, texture.height);
            var rightFruitPart = new Rect(xPos, 0, texture.width - xPos, texture.height);
            
            
            SpawnBlock(blockSprite, rightFruitPart, rightPivot, entity, destroyContext, 0);
            SpawnBlock(blockSprite, leftFruitPart, leftPivot, entity, destroyContext, 180);
        }

        private void SpawnBlock(Sprite originalSprite, Rect fruitPart, float pivot, Block original,
            BlockDestroyContext fruitDestroyContext, float additionalNewBlockAngle)
        {
            var block = _uncuttableBlockFactory.Create(new FromBlockBlockCreationContext
            {
                OriginalBlock = original,
                BlockNewSprite = CreateSprite(originalSprite, fruitPart, pivot),
                MultiplySpeedBy = CalculateAdditionalSpeed(fruitDestroyContext),
                Offset = GetBlockPartOffsetFromCenter(original, additionalNewBlockAngle),
                Direction = GetDirectionBasedOnSlicingVectorAngleToXAxis(fruitDestroyContext.SlicingVector),
                Scale = 1f
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

        private static Sprite CreateSprite(Sprite originalSprite, Rect fruitPart, float pivot) => 
            Sprite.Create(originalSprite.texture, fruitPart, Vector2.one * pivot, originalSprite.pixelsPerUnit);
    }
}