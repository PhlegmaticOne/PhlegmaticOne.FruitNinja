using System.Collections.Generic;
using Entities.Base;
using UnityEngine;

namespace Game.Scripts.Blocks
{
    public class BlocksSystem : MonoBehaviour
    {
        private readonly List<CuttableBlock> _blocksOnField = new List<CuttableBlock>();
        
        public IReadOnlyList<CuttableBlock> BlocksOnField => _blocksOnField;

        public void AddBlock(CuttableBlock cuttableBlock)
        {
            cuttableBlock.ScreenLeaved += CuttableBlockOnScreenLeaved;
            _blocksOnField.Add(cuttableBlock);
        }

        private void CuttableBlockOnScreenLeaved(Block block)
        {
            if (block is CuttableBlock cuttableBlock)
            {
                cuttableBlock.ScreenLeaved -= CuttableBlockOnScreenLeaved;
                _blocksOnField.Remove(cuttableBlock);
                cuttableBlock.PermanentDestroy();
            }
        }
    }
}