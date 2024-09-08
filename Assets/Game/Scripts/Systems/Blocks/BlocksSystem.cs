using System;
using System.Collections.Generic;
using Entities.Base;
using UnityEngine;

namespace Systems.Blocks
{
    public class BlocksSystem : MonoBehaviour
    {
        private readonly List<Block> _blocksOnField = new List<Block>();
        public event Action<Block> BlockAdded;
        public event Action<Block> BlockRemoved; 
        public IReadOnlyList<Block> AllBlocksOnField => _blocksOnField;
        public void AddBlock(Block block)
        {
            _blocksOnField.Add(block);
            OnBlockAdded(block);
        }

        public void RemoveBlock(Block block)
        {
            _blocksOnField.Remove(block);
            OnBlockRemoved(block);
        }

        private void OnBlockAdded(Block block) => BlockAdded?.Invoke(block);
        private void OnBlockRemoved(Block block) => BlockRemoved?.Invoke(block);
    }
}