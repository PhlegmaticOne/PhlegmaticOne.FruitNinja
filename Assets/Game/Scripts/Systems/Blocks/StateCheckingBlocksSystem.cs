using System;
using Abstracts.Stages;
using Entities.Base;
using UnityEngine;

namespace Systems.Blocks
{
    public class StateCheckingBlocksSystem : MonoBehaviour, IStageable
    {
        [SerializeField] private BlocksSystem _blocksSystem;
        [SerializeField] private Camera _camera;
        public event Action AllBlocksFallen;
        public event Action<Block> BlockFallen;
        public int BlocksCount => _blocksSystem.AllBlocksOnField.Count;
        public void Enable() => _blocksSystem.BlockAdded += BlocksSystemOnBlockAdded;
        public void Disable() => _blocksSystem.BlockAdded -= BlocksSystemOnBlockAdded;
        private void BlocksSystemOnBlockAdded(Block block) => block.Fallen += BlockOnFallen;

        private void BlockOnFallen(Block block)
        {
            if (block.transform.position.y > _camera.orthographicSize)
            {
                return;
            }
            
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
        public void OnAllBlocksFallen() => AllBlocksFallen?.Invoke();
    }
}