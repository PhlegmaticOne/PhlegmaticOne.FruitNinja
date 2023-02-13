using Abstracts.Animations;
using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.ViewCommands.Models;
using Configurations;
using UnityEngine;

namespace Entities.Base
{
    public class CuttableBlock : Block
    {
        private ICuttableBlockOnDestroyCommand _onDestroyViewCommand;
        public void Initialize(BlockInfo blockInfo, 
            ITransformAnimation transformAnimation,
            ICuttableBlockOnDestroyCommand onDestroyViewCommand)
        {
            base.Initialize(blockInfo, transformAnimation);
            _onDestroyViewCommand = onDestroyViewCommand;
        }

        public void Cut(SliceContext sliceContext)
        {
            _onDestroyViewCommand.OnDestroy(this, new BlockDestroyContext
            {
                SlicingVector = sliceContext.SlicingVector,
                SlicingPoint = sliceContext.SlicePoint,
                TimeSinceLastSlicing = sliceContext.TimeSinceLastSlicing
            });
            PermanentDestroy();
        }
    }

    public class SliceContext
    {
        public Vector2 SlicePoint { get; set; }
        public Vector2 SlicingVector { get; set; }
        public float TimeSinceLastSlicing { get; set; }
    }
}