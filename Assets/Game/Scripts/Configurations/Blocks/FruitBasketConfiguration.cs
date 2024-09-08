using System;
using System.Collections.Generic;
using Configurations.Base;
using UnityEngine;

namespace Configurations.Blocks
{
    [CreateAssetMenu(menuName = "Blocks/Create fruit basket configuration", order = 0)]
    public class FruitBasketConfiguration : ScriptableObject, IBlockConfiguration
    {
        [SerializeField] private List<BlockInfo> _fruitsAvailable;
        [SerializeField] private MinMaxInfo<int> _blocksCountInfo;
        [SerializeField] private float _explosionPower;
        [SerializeField] private CutSprites _cutSprites;
        [Range(0.1f, 1f)]
        [SerializeField] private float _delayAfterSlicing;

        public List<BlockInfo> FruitsAvailable => _fruitsAvailable;
        public MinMaxInfo<int> BlocksCountInfo => _blocksCountInfo;
        public float ExplosionPower => _explosionPower;
        public CutSprites CutSprites => _cutSprites;
        public float DelayAfterSlicing => _delayAfterSlicing;
    }

    [Serializable]
    public class CutSprites
    {
        [SerializeField] private Sprite _leftHalf;
        [SerializeField] private Sprite _rightHalf;

        public Sprite LeftHalf => _leftHalf;
        public Sprite RightHalf => _rightHalf;
    }
}