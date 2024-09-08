using System.Collections.Generic;
using UnityEngine;

namespace Configurations.Blocks
{
    [CreateAssetMenu(menuName = "Blocks/Create metamorphic block configuration", order = 0)]
    public class MetamorphicBlockConfiguration : ScriptableObject, IBlockConfiguration
    {
        [SerializeField] private List<BlockInfo> _canTransformTo;
        [SerializeField] private float _transformPeriod;
        public List<BlockInfo> CanTransformTo => _canTransformTo;
        public float TransformPeriod => _transformPeriod;
    }
}