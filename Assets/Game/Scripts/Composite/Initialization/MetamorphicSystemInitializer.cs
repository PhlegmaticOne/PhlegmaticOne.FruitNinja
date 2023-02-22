using Composite.Base;
using Systems.Blocks;
using Systems.Cutting;
using Systems.Metamorphic;
using UnityEngine;

namespace Composite.Initialization
{
    public class MetamorphicSystemInitializer : CompositeInitializer
    {
        [SerializeField] private MetamorphicSystem _metamorphicSystem;
        [SerializeField] private BlocksSystem _blocksSystem;
        [SerializeField] private StateCheckingBlocksSystem _stateCheckingBlocksSystem;
        [SerializeField] private SpawningSystemInitializer _spawningSystemInitializer;
        [SerializeField] private CuttingSystem _cuttingSystem;
        public override void Initialize()
        {
            _metamorphicSystem.Initialize(_blocksSystem, _stateCheckingBlocksSystem, _cuttingSystem,
                _spawningSystemInitializer.AbstractSpawner,
                _spawningSystemInitializer.SpawnPoliciesProvider);
        }
    }
}