using UnityEngine;

namespace Entities.Base
{
    public class HeartBonus : CuttableBlock
    {
        [SerializeField] private float _multiplyAcceleartionBy;
        [SerializeField] private float _multiplySpeedBy;
        protected override void OnAccelerationSetting(ref float acceleration) => acceleration *= _multiplyAcceleartionBy;
        protected override void OnSpeedAdding(ref Vector3 speedToAdd) => speedToAdd *= _multiplySpeedBy;
    }
}