using Abstracts.Initialization;
using Composite.Base;
using InputSystem;
using Systems.Blocks;
using Systems.Follow;
using UnityEngine;

namespace Composite.Initialization
{
    public class FollowSystemInitializer : CompositeInitializer
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private FollowSystem _followSystem;
        [SerializeField] private BlocksSystem _blocksSystem;
        [SerializeField] private InitializerBase<IInputSystemFactory> _inputSystemInitializer;
        
        public override void Initialize() => 
            _followSystem.Initialize(_blocksSystem, _inputSystemInitializer.Create().CreateInput(), _camera);
    }
}