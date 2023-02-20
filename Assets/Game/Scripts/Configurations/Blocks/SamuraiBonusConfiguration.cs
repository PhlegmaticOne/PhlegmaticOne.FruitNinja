using UnityEngine;

namespace Configurations.Blocks
{
    [CreateAssetMenu(menuName = "Blocks/Create samurai bonus configuration", order = 0)]
    public class SamuraiBonusConfiguration : ScriptableObject, IBlockConfiguration
    {
        [SerializeField] private int _duration;
        [SerializeField] private float _increaseBlocksCountInPackageBy;
        [SerializeField] private float _decreasePackageIntervalsBy;
        
        public int Duration => _duration;
        public float IncreaseBlocksCountInPackageBy => _increaseBlocksCountInPackageBy;
        public float DecreasePackageIntervalsBy => _decreasePackageIntervalsBy;
    }
}