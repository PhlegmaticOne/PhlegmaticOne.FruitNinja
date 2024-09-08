using Configurations.Blocks;
using Entities.Base;
using UnityEngine;

namespace Entities
{
    public class FruitBasket : Block
    {
        [SerializeField] private FruitBasketConfiguration _fruitBasketConfiguration;
        public override IBlockConfiguration BlockConfiguration => _fruitBasketConfiguration;
    }
}