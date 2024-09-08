using Composite.Base;
using Configurations.Systems;
using Systems.Combos;
using UnityEngine;

namespace Composite.Initialization
{
    public class ComboSystemInitializer : CompositeInitializer
    {
        [SerializeField] private ComboSystemConfiguration _comboSystemConfiguration;
        [SerializeField] private ComboSystem _comboSystem;
        
        public override void Initialize() => _comboSystem.Initialize(_comboSystemConfiguration);
    }
}