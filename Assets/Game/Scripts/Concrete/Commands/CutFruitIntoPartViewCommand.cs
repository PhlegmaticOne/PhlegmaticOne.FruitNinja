using Abstracts.Commands;
using Abstracts.Factories;
using Concrete.Factories.Blocks;
using Entities.Base;
using Systems.Blocks;
using UnityEngine;

namespace Concrete.Commands
{
    public class CutFruitIntoPartViewCommand : IOnDestroyViewCommand<CuttableBlock, FruitDestroyContext>
    {
        private readonly IFactory<FromBlockBlockCreationContext, UncuttableBlock> _uncuttableBlockFactory;
        private readonly BlocksSystem _blocksSystem;

        public CutFruitIntoPartViewCommand(
            IFactory<FromBlockBlockCreationContext, UncuttableBlock> uncuttableBlockFactory, 
            BlocksSystem blocksSystem)
        {
            _uncuttableBlockFactory = uncuttableBlockFactory;
            _blocksSystem = blocksSystem;
        }
        
        public void OnDestroy(CuttableBlock entity, FruitDestroyContext destroyContext)
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
            Block original, FruitDestroyContext fruitDestroyContext)
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