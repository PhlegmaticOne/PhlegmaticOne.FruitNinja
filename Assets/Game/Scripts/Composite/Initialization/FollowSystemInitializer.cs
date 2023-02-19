using Abstracts.Initialization;
using Composite.Base;
using InputSystem;
using Systems.Follow;
using UnityEngine;

namespace Composite.Initialization
{
    public class FollowSystemInitializer : CompositeInitializer
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private FollowSystem _followSystem;
        [SerializeField] private InitializerBase<IInputSystemFactory> _inputSystemInitializer;
        
        public override void Initialize() => 
            _followSystem.Initialize(_inputSystemInitializer.Create().CreateInput(), _camera);
    }
}