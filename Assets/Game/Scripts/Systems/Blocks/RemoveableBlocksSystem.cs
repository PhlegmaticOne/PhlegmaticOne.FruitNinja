using System;
using Entities.Base;
using UnityEngine;

namespace Systems.Blocks
{
    public class RemoveableBlocksSystem : MonoBehaviour
    {
        [SerializeField] private BlocksSystem _blocksSystem;

        private void Start() => _blocksSystem.BlockAdded += BlocksSystemOnBlockAdded;

        private void BlocksSystemOnBlockAdded(Block block) => block.OnDestroying += BlockOnOnDestroying;

        private void BlockOnOnDestroying(Block block)
        {
            _blocksSystem.AllBlocksOnField.Remove(block);
            block.OnDestroying -= BlockOnOnDestroying;
            block.PermanentDestroy();
        }

        private void OnDestroy() => _blocksSystem.BlockAdded -= BlocksSystemOnBlockAdded;
    }
}