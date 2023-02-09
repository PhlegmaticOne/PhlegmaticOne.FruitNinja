using Concrete.Commands.ViewCommands.Base;
using Concrete.Commands.ViewCommands.Models;
using Concrete.Factories.Blocks.Base;
using Concrete.Factories.Blocks.Models;
using Entities.Base;
using Systems.Blocks;
using UnityEngine;

namespace Concrete.Commands.ViewCommands
{
    public class CutFruitIntoPartViewCommand : ICuttableBlockOnDestroyViewCommand
    {
        private readonly IUncuttableBlocksFactory _uncuttableBlockFactory;
        private readonly BlocksSystem _blocksSystem;

        public CutFruitIntoPartViewCommand(IUncuttableBlocksFactory uncuttableBlockFactory, BlocksSystem blocksSystem)
        {
            _uncuttableBlockFactory = uncuttableBlockFactory;
            _blocksSystem = blocksSystem;
        }
        
        public void OnDestroy(CuttableBlock entity, BlockDestroyContext destroyContext)
        {
            var blockSprite = entity.BlockInfo.Sprite;
            var texture = blockSprite.texture;
            var xPos = texture.width / 2.0f;
            var rightPivot = (texture.width - xPos) / texture.width;
            var leftPivot = 1.0f - rightPivot;
            var leftFruitPart = new Rect(0, 0, xPos, texture.height);
            var rightFruitPart = new Rect(xPos, 0, texture.width - xPos, texture.height);

            CreateUncuttableBlock(blockSprite, leftFruitPart, leftPivot, -1, entity, destroyContext);
            CreateUncuttableBlock(blockSprite, rightFruitPart, rightPivot, 1, entity, destroyContext);
        }

        private void CreateUncuttableBlock(Sprite originalSprite, Rect fruitPart, float pivot, int direction,
            Block original, BlockDestroyContext fruitDestroyContext)
        {
            var sprite = Sprite.Create(originalSprite.texture, fruitPart, Vector2.one * pivot, originalSprite.pixelsPerUnit);
            var rotation = Quaternion.AngleAxis(90 * direction, Vector3.forward) * fruitDestroyContext.SlicingVector;
            var block = _uncuttableBlockFactory.Create(new FromBlockBlockCreationContext()
            {
                OriginalBlock = original,
                BlockNewSprite = sprite,
                MultiplySpeedBy = rotation.normalized
            });
            _blocksSystem.AddBlock(block);
        }
    }
}