using Configurations.Blocks;
using Entities.Base;
using UnityEngine;

namespace Entities
{
    public class Ice : Block
    {
        [SerializeField] private IceBlockConfiguration _iceBlockConfiguration;
        public override IBlockConfiguration BlockConfiguration => _iceBlockConfiguration;
    }
}