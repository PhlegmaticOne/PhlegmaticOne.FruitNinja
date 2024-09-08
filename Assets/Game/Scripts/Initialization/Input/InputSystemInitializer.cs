using Abstracts.Initialization;
using InputSystem;
using UnityEngine;

namespace Initialization.Input
{
    public class InputSystemInitializer : InitializerBase<IInputSystemFactory>
    {
        private InputSystemFactory _inputSystemFactory;
        public override IInputSystemFactory Create() => _inputSystemFactory ??= new InputSystemFactory();
    }
}