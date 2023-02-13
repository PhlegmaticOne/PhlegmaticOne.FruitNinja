using Abstracts.Initialization;
using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.ViewCommands;
using Systems.Health;
using UnityEngine;

namespace Initialization.BlockCommands
{
    public class RemoveHeartCommandInitializer : InitializerBase<ICuttableBlockOnDestroyCommand>
    {
        [SerializeField] private HealthSystem _healthSystem;
        public override ICuttableBlockOnDestroyCommand Create() => 
            new RemoveHeartCommand(_healthSystem);
    }
}