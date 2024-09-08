using Configurations.Blocks;
using Entities.Base;
using UnityEngine;

namespace Entities
{
    public class Brick : Block
    {
        [SerializeField] private BrickBlockConfiguration _brickBlockConfiguration;
        public override IBlockConfiguration BlockConfiguration => _brickBlockConfiguration;
    }
}