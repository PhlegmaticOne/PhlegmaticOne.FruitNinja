using Abstracts.Animations;
using Concrete.Commands.ModelCommands.Base;
using Concrete.Commands.ViewCommands.Base;
using Concrete.Commands.ViewCommands.Models;
using Configurations;
using UnityEngine;

namespace Entities.Base
{
    public class CuttableBlock : Block
    {
        private ICuttableBlockOnDestroyCommand _onDestroyCommand;
        private ICuttableBlockOnDestroyViewCommand _onDestroyViewCommand;
        public void Initialize(BlockInfo blockInfo, 
            ITransformAnimation transformAnimation,
            ICuttableBlockOnDestroyCommand onDestroyCommand,
            ICuttableBlockOnDestroyViewCommand onDestroyViewCommand)
        {
            base.Initialize(blockInfo, transformAnimation);
            _onDestroyViewCommand = onDestroyViewCommand;
            _onDestroyCommand = onDestroyCommand;
        }

        public void Cut(Vector2 slicingVector, Vector2 slicingPoint)
        {
            _onDestroyViewCommand.OnDestroy(this, new BlockDestroyContext
            {
                SlicingVector = slicingVector,
                SlicingPoint = slicingPoint
            });
            _onDestroyCommand.OnDestroy(this);
            PermanentDestroy();
        }
    }
}