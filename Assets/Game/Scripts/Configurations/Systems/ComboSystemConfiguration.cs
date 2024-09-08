using UnityEngine;

namespace Configurations.Systems
{
    [CreateAssetMenu(menuName = "Systems/Create combo system configuration", order = 0)]
    public class ComboSystemConfiguration : ScriptableObject
    {
        [SerializeField] private float _maxComboDelay;
        [SerializeField] private int _maxComboCount;

        public float MaxComboDelay => _maxComboDelay;
        public int MaxComboCount => _maxComboCount;
    }
}