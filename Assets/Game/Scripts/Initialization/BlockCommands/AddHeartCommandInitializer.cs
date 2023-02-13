using Abstracts.Initialization;
using Concrete.Commands.BlockCommands;
using Concrete.Commands.BlockCommands.Base;
using Systems.Health;
using UnityEngine;

namespace Initialization.BlockCommands
{
    public class AddHeartCommandInitializer : InitializerBase<ICuttableBlockOnDestroyCommand>
    {
        [SerializeField] private HealthSystem _healthSystem;
        public override ICuttableBlockOnDestroyCommand Create() => new AddHeartCommand(_healthSystem);
    }
}