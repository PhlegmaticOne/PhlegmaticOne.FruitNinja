using System;
using System.Collections.Generic;
using Entities.Base;
using UnityEngine;

namespace Systems.Blocks
{
    public class BlocksSystem : MonoBehaviour
    {
        private readonly List<Block> _blocksOnField = new List<Block>();
        public IList<Block> AllBlocksOnField => _blocksOnField;
        public event Action<Block> BlockAdded; 

        public void AddBlock(Block block)
        {
            _blocksOnField.Add(block);
            BlockAdded?.Invoke(block);
        }
    }
}