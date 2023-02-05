using Abstracts.Animations;
using Abstracts.Commands;
using Concrete.Commands;
using Configurations;
using UnityEngine;

namespace Entities.Base
{
    public class CuttableBlock : Block
    {
        private IOnDestroyViewCommand<CuttableBlock, FruitDestroyContext> _onDestroyViewCommand;
        public void Initialize(BlockInfo blockInfo, 
            ITransformAnimation transformAnimation,
            IOnDestroyViewCommand<CuttableBlock, FruitDestroyContext> onDestroyViewCommand)
        {
            base.Initialize(blockInfo, transformAnimation);
            _onDestroyViewCommand = onDestroyViewCommand;
        }

        public void Cut(Vector2 slicingVector, Vector2 slicingPoint)
        {
            _onDestroyViewCommand.OnDestroy(this, new FruitDestroyContext
            {
                SlicingVector = slicingVector,
                SlicingPoint = slicingPoint
            });
            PermanentDestroy();
        }
    }
}