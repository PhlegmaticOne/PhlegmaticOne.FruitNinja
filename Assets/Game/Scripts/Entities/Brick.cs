using Configurations.Blocks;
using Entities.Base;
using UnityEngine;

namespace Entities
{
    public class Brick : CuttableBlock
    {
        [SerializeField] private BrickBlockConfiguration _brickBlockConfiguration;
        public override IBlockConfiguration BlockConfiguration => _brickBlockConfiguration;
    }
}