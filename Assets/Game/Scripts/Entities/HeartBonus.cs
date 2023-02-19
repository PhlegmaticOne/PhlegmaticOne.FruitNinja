using Configurations.Blocks;
using Entities.Base;
using UnityEngine;

namespace Entities
{
    public class HeartBonus : CuttableBlock
    {
        [SerializeField] private HealthBonusConfiguration _heartBonusConfiguration;
        public override IBlockConfiguration BlockConfiguration => _heartBonusConfiguration;
        
        protected override void OnAccelerationSetting(ref float acceleration) => 
            acceleration *= _heartBonusConfiguration.MultiplyAccelerationBy;
        protected override void OnSpeedAdding(ref Vector3 speedToAdd) => 
            speedToAdd *= _heartBonusConfiguration.MultiplySpeedBy;
    }
}