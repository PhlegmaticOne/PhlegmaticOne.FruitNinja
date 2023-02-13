using Abstracts.Initialization;
using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.ViewCommands;
using UnityEngine;

namespace Initialization.BlockCommands
{
    public class SpawnParticleCommandInitializer : InitializerBase<ICuttableBlockOnDestroyCommand>
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private Transform _uiTransform;
        
        public override ICuttableBlockOnDestroyCommand Create() => 
            new SpawnParticleCommand(_particleSystem, _uiTransform);
    }
}