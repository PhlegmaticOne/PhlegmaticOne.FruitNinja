using Systems.Health;
using UnityEngine;

namespace Configurations.Systems
{
    [CreateAssetMenu(menuName = "Systems/Create health system configuration", order = 0)]
    public class HealthSystemConfiguration : ScriptableObject
    {
        [SerializeField] private int _startHealthCount;
        [SerializeField] private int _maxHealthCount;
        [SerializeField] private float _transitionToHealthBarTime;
        [SerializeField] private HealthView _healthPrefab;

        public int StartHealthCount => _startHealthCount;
        public int MaxHealthCount => _maxHealthCount;
        public HealthView HealthViewPrefab => _healthPrefab;
        public float TransitionToHealthBarTime => _transitionToHealthBarTime;
    }
}