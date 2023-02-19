using System;
using Abstracts.Animations;
using Configurations;
using Entities.View;
using Physics;
using UnityEngine;

namespace Entities.Base
{
    public class Block : GravityObject
    {
        [SerializeField] protected BlockView _blockView;
        private bool _isDestroyed;
        
        private ITransformAnimation _transformAnimation;
        public BlockInfo BlockInfo { get; private set; }
        public event Action<Block> Fallen; 

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
}