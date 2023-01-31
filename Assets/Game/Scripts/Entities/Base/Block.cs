using System;
using Configurations;
using Physics;
using UnityEngine;

namespace Entities.Base
{
    public class Block : GravityObject
    {
        [SerializeField] private BlockView _blockView;
        public Sprite BlockSprite { get; private set; }
        
        public event Action<Block> ScreenLeaved; 

        public void Initialize(MovementBase movementBase, BlockInfo blockInfo)
        {
            base.Initialize(movementBase);
            _blockView.SetSprite(blockInfo.Sprite);
            BlockSprite = blockInfo.Sprite;
        }

        public void PermanentDestroy() => Destroy(gameObject);
        private void OnBecameInvisible() => ScreenLeaved?.Invoke(this);
    }
}