using UnityEngine;

namespace Configurations.Blocks
{
    [CreateAssetMenu(menuName = "Blocks/Create brick configuration", order = 0)]
    public class BrickBlockConfiguration : ScriptableObject, IBlockConfiguration
    {
        [SerializeField] private bool _blocksInput;
        public bool BlocksInput => _blocksInput;
    }
}