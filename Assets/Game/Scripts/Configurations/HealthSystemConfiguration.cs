using Systems.Health;
using UnityEngine;

namespace Configurations
{
    [CreateAssetMenu(menuName = "Create health configuration", order = 0)]
    public class HealthSystemConfiguration : ScriptableObject
    {
        [SerializeField] private int _startHealthCount;
        [SerializeField] private int _maxHealthCount;
        [SerializeField] private HealthView _healthPrefab;

        public int StartHealthCount => _startHealthCount;
        public int MaxHealthCount => _maxHealthCount;
        public HealthView HealthViewPrefab => _healthPrefab;
    }
}