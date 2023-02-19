using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.BlockCommands.Models;
using Entities.Base;
using InputSystem;

namespace Concrete.Commands.BlockCommands
{
    public class DisableInputCommand : ICuttableBlockOnDestroyCommand
    {
        private readonly IInputSystem _inputSystem;
        private readonly bool _isDisable;

        public DisableInputCommand(IInputSystem inputSystem, bool isDisable)
        {
            _inputSystem = inputSystem;
            _isDisable = isDisable;
            _inputSystem.Ended += InputSystemOnEnded;
        }
        
        public void OnDestroy(CuttableBlock entity, BlockDestroyContext destroyContext)
        {
            if (_isDisable == false)
            {
                return;
            }
            
            _inputSystem.MakeInvalid();
        }
        
        private void InputSystemOnEnded()
        {
            if (_inputSystem.IsValid == false)
            {
                _inputSystem.Reset();
            }
        }
    }
}