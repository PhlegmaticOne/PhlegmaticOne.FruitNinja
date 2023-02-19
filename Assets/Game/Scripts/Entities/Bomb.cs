using Configurations.Blocks;
using Entities.Base;
using UnityEngine;

namespace Entities
{
    public class Bomb : CuttableBlock
    {
        [SerializeField] private BombConfiguration _bombConfiguration;

        public override IBlockConfiguration BlockConfiguration => _bombConfiguration;
    }
}