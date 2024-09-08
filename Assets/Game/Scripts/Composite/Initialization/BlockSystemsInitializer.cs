using Composite.Base;
using Systems.Blocks;
using UnityEngine;

namespace Composite.Initialization
{
    public class BlockSystemsInitializer : CompositeInitializer
    {
        [SerializeField] private BlocksSystem _blocksSystem;
        [SerializeField] private FilteringBlocksSystem _filteringBlocksSystem;
        [SerializeField] private StateCheckingBlocksSystem _stateCheckingBlocksSystem;
        
        public override void Initialize()
        {
            _filteringBlocksSystem.Initialize(_blocksSystem);
            _stateCheckingBlocksSystem.Initialize(_blocksSystem);
        }
    }
}