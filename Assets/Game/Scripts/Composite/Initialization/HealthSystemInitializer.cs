using Composite.Base;
using Configurations.Systems;
using Systems.Blocks;
using Systems.Health;
using UnityEngine;

namespace Composite.Initialization
{
    public class HealthSystemInitializer : CompositeInitializer
    {
        [SerializeField] private HealthSystemConfiguration _healthSystemConfiguration;
        [SerializeField] private HealthController _healthController;
        [SerializeField] private StateCheckingBlocksSystem _stateCheckingBlocksSystem;
        [SerializeField] private HealthSystem _healthSystem;
        [SerializeField] private Camera _camera;
        public override void Initialize()
        {
            _healthSystem.Initialize(_healthSystemConfiguration, _camera);
            _healthController.Initialize(_healthSystem, _stateCheckingBlocksSystem);
        }
    }
}