using Abstracts.Initialization;
using Concrete.Commands.ViewCommands;
using Concrete.Commands.ViewCommands.Base;
using UnityEngine;

namespace Initialization.ViewCommands
{
    public class SpawnJuiceParticleCommandInitializer : InitializerBase<ICuttableBlockOnDestroyViewCommand>
    {
        [SerializeField] private ParticleSystem _particlePrefab;
        [SerializeField] private Transform _effectsTransform;
        public override ICuttableBlockOnDestroyViewCommand Create() => 
            new SpawnJuiceParticleViewCommand(_particlePrefab, _effectsTransform);
    }
}