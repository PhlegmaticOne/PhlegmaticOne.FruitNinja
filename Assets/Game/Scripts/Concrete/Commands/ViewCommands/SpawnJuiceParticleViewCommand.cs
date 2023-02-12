using Concrete.Commands.ViewCommands.Base;
using Concrete.Commands.ViewCommands.Models;
using Entities.Base;
using UnityEngine;

namespace Concrete.Commands.ViewCommands
{
    public class SpawnJuiceParticleViewCommand : ICuttableBlockOnDestroyViewCommand
    {
        private readonly ParticleSystem _juiceParticleSystem;
        private readonly Transform _effectsParent;

        public SpawnJuiceParticleViewCommand(ParticleSystem juiceParticleSystem, Transform effectsParent)
        {
            _juiceParticleSystem = juiceParticleSystem;
            _effectsParent = effectsParent;
        }

        public void OnDestroy(CuttableBlock entity, BlockDestroyContext fruitDestroyContext)
        {
            var particleSystem = Object.Instantiate(_juiceParticleSystem, _effectsParent, true);
            var module = particleSystem.main;
            module.startColor = new ParticleSystem.MinMaxGradient(entity.BlockInfo.JuiceEffectColor);
            particleSystem.transform.position = entity.transform.position;
            particleSystem.Play();
            Object.Destroy(particleSystem.gameObject, particleSystem.main.duration + 1);
        }
    }
}