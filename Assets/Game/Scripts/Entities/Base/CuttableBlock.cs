﻿using Abstracts.Animations;
using Concrete.Commands.ViewCommands.Base;
using Concrete.Commands.ViewCommands.Models;
using Configurations;
using UnityEngine;

namespace Entities.Base
{
    public class CuttableBlock : Block
    {
        private ICuttableBlockOnDestroyViewCommand _onDestroyViewCommand;
        public void Initialize(BlockInfo blockInfo, 
            ITransformAnimation transformAnimation,
            ICuttableBlockOnDestroyViewCommand onDestroyViewCommand)
        {
            base.Initialize(blockInfo, transformAnimation);
            _onDestroyViewCommand = onDestroyViewCommand;
        }

        public virtual bool SupportsCombos => true;

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
        
        public int NumberInCombosSequence { get; set; }
    }
}