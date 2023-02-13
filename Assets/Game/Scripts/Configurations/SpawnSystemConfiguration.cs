using System.Collections.Generic;
using UnityEngine;

namespace Configurations
{
    [CreateAssetMenu(menuName = "Create spawn configuration", order = 0)]
    public class SpawnSystemConfiguration : ScriptableObject
    {
        [SerializeField] private List<BlockInfo> _fruitsAvailable;
        [SerializeField] private List<ExtraBlockConfiguration> _debufsAvailable;
        [SerializeField] private List<ExtraBlockConfiguration> _bonusesAvailable;
        [SerializeField] private SpawningSystemInfo _spawningSystemInfo;

        public List<BlockInfo> FruitsAvailable => _fruitsAvailable;
        public List<ExtraBlockConfiguration> DebufsAvailable => _debufsAvailable;
        public List<ExtraBlockConfiguration> BonusesAvailable => _bonusesAvailable;
        
        public SpawningSystemInfo SpawningSystemInfo => _spawningSystemInfo;
    }
}