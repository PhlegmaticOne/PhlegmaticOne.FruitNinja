using Configurations.Blocks;
using Entities.Base;
using UnityEngine;

namespace Entities
{
    public class Fruit : CuttableBlock
    {
        [SerializeField] private FruitBlockConfiguration _fruitBlockConfiguration;
        
        public override IBlockConfiguration BlockConfiguration => _fruitBlockConfiguration;
    }
}