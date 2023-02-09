using System;
using Abstracts.Stages;
using Entities.Base;
using UnityEngine;

namespace Systems.Blocks
{
    public class StateCheckingBlocksSystem : MonoBehaviour, IStageable
    {
        [SerializeField] private BlocksSystem _blocksSystem;
        public event Action AllBlocksFallen;
        public event Action<Block> BlockFallen;
        public void Enable() => _blocksSystem.BlockAdded += BlocksSystemOnBlockAdded;
        public void Disable() => _blocksSystem.BlockAdded -= BlocksSystemOnBlockAdded;
        private void BlocksSystemOnBlockAdded(Block block) => block.Fallen += BlockOnFallen;

        private void BlockOnFallen(Block block)
        {
            _blocksSystem.RemoveBlock(block);
            block.Fallen -= BlockOnFallen;
            block.PermanentDestroy();
            OnBlockFallen(block);

            if (_blocksSystem.AllBlocksOnField.Count == 0)
            {
                OnAllBlocksFallen();
            }
        }

        private void OnBlockFallen(Block block) => BlockFallen?.Invoke(block);
        private void OnAllBlocksFallen() => AllBlocksFallen?.Invoke();
    }
}