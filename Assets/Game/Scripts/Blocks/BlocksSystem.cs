using System.Collections.Generic;
using System.Linq;
using Entities.Base;
using UnityEngine;

namespace Game.Scripts.Blocks
{
    public class BlocksSystem : MonoBehaviour
    {
        private readonly List<Block> _blocksOnField = new List<Block>();
        
        public IEnumerable<CuttableBlock> CuttableBlocksOnField =>
            _blocksOnField.OfType<CuttableBlock>();

        public void AddBlock(Block block)
        {
            block.ScreenLeaved += CuttableBlockOnScreenLeaved;
            _blocksOnField.Add(block);
        }

        private void CuttableBlockOnScreenLeaved(Block block)
        {
            block.ScreenLeaved -= CuttableBlockOnScreenLeaved;
            _blocksOnField.Remove(block);
            block.PermanentDestroy();
        }
    }
}