using Configurations.Blocks;
using Entities.Base;
using UnityEngine;

namespace Entities
{
    public class Ice : CuttableBlock
    {
        [SerializeField] private IceBlockConfiguration _iceBlockConfiguration;
        public override IBlockConfiguration BlockConfiguration => _iceBlockConfiguration;
    }
}