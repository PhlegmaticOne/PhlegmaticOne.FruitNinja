using Systems.Cutting;
using UnityEngine;

namespace Configurations.Systems
{
    [CreateAssetMenu(menuName = "Systems/Create cutting system configuration", order = 0)]
    public class CuttingSystemConfiguration : ScriptableObject
    {
        [SerializeField] private float _minSpeedToSlice;
        [SerializeField] private Blade _blade;
        
        public float MinSpeedToSlice => _minSpeedToSlice;
        public Blade Blade => _blade;
    }
}