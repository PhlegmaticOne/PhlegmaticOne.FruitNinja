using Configurations.Blocks;
using Entities.Base;
using UnityEngine;

namespace Entities
{
    public class SamuraiBonus : CuttableBlock
    {
        [SerializeField] private SamuraiBonusConfiguration _samuraiBonusConfiguration;
        public override IBlockConfiguration BlockConfiguration => _samuraiBonusConfiguration;
    }
}