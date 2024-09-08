using UnityEngine;

namespace Configurations.Spawning
{
    [CreateAssetMenu(menuName = "Spawning/Create difficulty configuration", order = 0)]
    public class DifficultyConfiguration : ScriptableObject
    {
        [SerializeField] private int _maxDifficulty;
        [SerializeField] private int _maxIncreaseGravityBy;
        public int MaxDifficulty => _maxDifficulty;
        public int MaxIncreaseGravityBy => _maxIncreaseGravityBy;
    }
}