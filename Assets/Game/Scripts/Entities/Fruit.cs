using Configurations.Blocks;
using Entities.Base;
using UnityEngine;

namespace Entities
{
    public class Fruit : Block
    {
        [SerializeField] private FruitBlockConfiguration _fruitBlockConfiguration;
        
        public override IBlockConfiguration BlockConfiguration => _fruitBlockConfiguration;
    }
}