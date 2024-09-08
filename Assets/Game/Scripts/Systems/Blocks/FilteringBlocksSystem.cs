using System.Collections.Generic;
using System.Linq;
using Configurations;
using Entities.Base;
using UnityEngine;

namespace Systems.Blocks
{
    public class FilteringBlocksSystem : MonoBehaviour
    {
        private BlocksSystem _blocksSystem;
        public void Initialize(BlocksSystem blocksSystem) => _blocksSystem = blocksSystem;
        public List<Block> CuttableBlocksOnField => _blocksSystem.AllBlocksOnField
            .Where(x => x.IsCuttable).ToList();
        public List<Block> MagnetizedBlocksInRadius(Vector3 point, float radius) => 
            _blocksSystem.AllBlocksOnField
                .Where(x => x.BlockInfo.MagnetBehaviour == MagnetBehaviour.Magnetized && 
                            Vector3.Distance(x.transform.position, point) <= radius)
                .ToList();
    }
}