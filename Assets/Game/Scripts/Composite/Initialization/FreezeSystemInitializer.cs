using Composite.Base;
using Systems.Blocks;
using Systems.Freezing;
using UnityEngine;

namespace Composite.Initialization
{
    public class FreezeSystemInitializer : CompositeInitializer
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private FreezingSystem _freezingSystem;
        [SerializeField] private BlocksSystem _blocksSystem;
        
        public override void Initialize() => _freezingSystem.Initialize(_blocksSystem, _canvas);
    }
}