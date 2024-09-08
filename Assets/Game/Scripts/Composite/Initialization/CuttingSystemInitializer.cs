using Abstracts.Initialization;
using Composite.Base;
using Configurations.Systems;
using InputSystem;
using Systems.Blocks;
using Systems.Cutting;
using UnityEngine;

namespace Composite.Initialization
{
    public class CuttingSystemInitializer : CompositeInitializer
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _bladeTransform;
        [SerializeField] private CuttingSystemConfiguration _cuttingSystemConfiguration;
        [SerializeField] private CuttingSystem _cuttingSystem;
        [SerializeField] private FilteringBlocksSystem _filteringBlocksSystem;
        [SerializeField] private BlocksSystem _blocksSystem;
        [SerializeField] private InitializerBase<IInputSystemFactory> _inputSystemInitializer;

        public override void Initialize()
        {
            var inputSystemFactory = _inputSystemInitializer.Create();
            
            _cuttingSystem.Initialize(_cuttingSystemConfiguration,
                inputSystemFactory,
                _bladeTransform,
                _camera,
                _filteringBlocksSystem,
                _blocksSystem);
        }
    }
}