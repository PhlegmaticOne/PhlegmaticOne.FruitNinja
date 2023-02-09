using System.Collections.Generic;
using System.Linq;
using Entities.Base;
using UnityEngine;

namespace Systems.Blocks
{
    public class CuttableBlocksSystem : MonoBehaviour
    {
        [SerializeField] private BlocksSystem _blocksSystem;

        public IEnumerable<CuttableBlock> CuttableBlocksOnField => _blocksSystem.AllBlocksOnField.OfType<CuttableBlock>();
    }
}