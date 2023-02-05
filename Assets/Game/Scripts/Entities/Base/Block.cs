using System;
using Abstracts.Animations;
using Configurations;
using Physics;
using UnityEngine;

namespace Entities.Base
{
    public class Block : GravityObject
    {
        [SerializeField] protected BlockView _blockView;
        
        private ITransformAnimation _transformAnimation;
        public BlockInfo BlockInfo { get; private set; }
        public ITransformAnimation TransformAnimation => _transformAnimation;
        public event Action<Block> OnDestroying; 

        public void Initialize(BlockInfo blockInfo, ITransformAnimation transformAnimation)
        {
            BlockInfo = blockInfo;
            _transformAnimation = transformAnimation;
            _blockView.SetSprite(blockInfo.Sprite);
            _transformAnimation.Start(transform);
        }

        public void PermanentDestroy()
        {
            _transformAnimation.Stop(transform);
            Destroy(gameObject);
        }

        private void OnBecameInvisible() => InvokeOnDestroying();
        private void InvokeOnDestroying() => OnDestroying?.Invoke(this);
    }
}