using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.BlockCommands.Models;
using Configurations.Blocks;
using UnityEngine;

namespace Entities.Base
{
    public abstract class CuttableBlock : Block
    {
        private ICuttableBlockOnDestroyCommand _onDestroyViewCommand;
        
        public abstract IBlockConfiguration BlockConfiguration { get; }
        public void SetOnDestroyCommand(ICuttableBlockOnDestroyCommand onDestroyCommand) => 
            _onDestroyViewCommand = onDestroyCommand;

        public void Cut(SliceContext sliceContext)
        {
            _onDestroyViewCommand.OnDestroy(this, new BlockDestroyContext
            {
                SlicingVector = sliceContext.SlicingVector,
                SlicingPoint = sliceContext.SlicePoint,
            });
            PermanentDestroy();
        }
    }

    public class SliceContext
    {
        public Vector2 SlicePoint { get; set; }
        public Vector2 SlicingVector { get; set; }
    }
}