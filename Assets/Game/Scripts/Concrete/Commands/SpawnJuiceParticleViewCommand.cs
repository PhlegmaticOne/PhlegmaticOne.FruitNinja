using Abstracts.Commands;
using Entities.Base;
using UnityEngine;

namespace Concrete.Commands
{
    public class FruitOnDestroyViewCommand : IOnDestroyViewCommand<CuttableBlock, FruitDestroyContext>
    {
        private readonly ParticleSystem _juiceParticleSystem;
        private readonly Transform _effectsParent;

        public FruitOnDestroyViewCommand(ParticleSystem juiceParticleSystem, Transform effectsParent)
        {
            _juiceParticleSystem = juiceParticleSystem;
            _effectsParent = effectsParent;
        }

        public void OnDestroy(CuttableBlock entity, FruitDestroyContext fruitDestroyContext)
        {
            var particleSystem = Object.Instantiate(_juiceParticleSystem, _effectsParent, true);
            var module = particleSystem.main;
            module.startColor = new ParticleSystem.MinMaxGradient(entity.BlockInfo.JuiceEffectColor);
            particleSystem.transform.position = entity.transform.position;
            particleSystem.Play();
            Object.Destroy(particleSystem.gameObject, particleSystem.main.duration);
        }
    }
}