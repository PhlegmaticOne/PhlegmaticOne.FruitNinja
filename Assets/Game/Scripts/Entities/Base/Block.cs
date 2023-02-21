using System;
using Abstracts.Animations;
using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.BlockCommands.Models;
using Configurations;
using Configurations.Blocks;
using Entities.View;
using Physics;
using UnityEngine;

namespace Entities.Base
{
    public abstract class Block : GravityObject
    {
        private bool _isDestroyed;
        private ITransformAnimation _transformAnimation;
        private IBlockOnDestroyCommand _onDestroyViewCommand;
        
        [SerializeField] protected BlockView _blockView;
        
        public event Action<Block> Fallen; 
        public abstract IBlockConfiguration BlockConfiguration { get; }
        public BlockInfo BlockInfo { get; private set; }
        public bool IsCuttable => BlockInfo.IsCuttable;

        public void Initialize(BlockInfo blockInfo, ITransformAnimation transformAnimation)
        {
            BlockInfo = blockInfo;
            _transformAnimation = transformAnimation;
            _blockView.SetSprite(blockInfo.Sprite);
            _transformAnimation.Start(transform);
        }
        
        public void SetOnDestroyCommand(IBlockOnDestroyCommand onDestroyCommand) => 
            _onDestroyViewCommand = onDestroyCommand;

        public void Cut(SliceContext sliceContext)
        {
            if (IsCuttable == false)
            {
                return;
            }
            
            _onDestroyViewCommand.OnDestroy(this, new BlockDestroyContext
            {
                SlicingVector = sliceContext.SlicingVector,
                SlicingPoint = sliceContext.SlicePoint,
            });
            
            if (BlockInfo.DestroyOnCut)
            {
                PermanentDestroy();
            }
        }

        public void PermanentDestroy()
        {
            _transformAnimation.Stop(transform);
            _isDestroyed = true;
            Destroy(gameObject);
        }

        private void OnBecameInvisible()
        {
            if (_isDestroyed)
            {
                return;
            }
            OnFallen();
        }

        private void OnFallen() => Fallen?.Invoke(this);
    }
    
    public class SliceContext
    {
        public Vector2 SlicePoint { get; set; }
        public Vector2 SlicingVector { get; set; }
    }
}