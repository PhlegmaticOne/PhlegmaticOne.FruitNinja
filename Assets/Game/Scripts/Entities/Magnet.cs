using Configurations.Blocks;
using Entities.Base;
using UnityEngine;

namespace Entities
{
    public class Magnet : CuttableBlock
    {
        [SerializeField] private MagnetConfiguration _magnetConfiguration;
        public override IBlockConfiguration BlockConfiguration => _magnetConfiguration;
    }
}