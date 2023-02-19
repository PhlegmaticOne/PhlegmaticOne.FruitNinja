using Composite.Base;
using Systems.Blocks;
using Systems.Magnet;
using UnityEngine;

namespace Composite.Initialization
{
    public class MagnetSystemInitializer : CompositeInitializer
    {
        [SerializeField] private MagnetSystem _magnetSystem;
        [SerializeField] private FilteringBlocksSystem _filteringBlocksSystem;
        [SerializeField] private MagnetWaves _magnetWaves;

        public override void Initialize()
        {
            _magnetSystem.Initialize(_filteringBlocksSystem, _magnetWaves);
        }
    }
}