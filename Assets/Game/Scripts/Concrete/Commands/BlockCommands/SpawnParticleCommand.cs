﻿using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.BlockCommands.Models;
using Entities.Base;
using UnityEngine;

namespace Concrete.Commands.BlockCommands
{
    public class SpawnParticleCommand : IBlockOnDestroyCommand
    {
        private readonly ParticleSystem _particleSystem;
        private readonly Transform _effectsTransform;

        public SpawnParticleCommand(ParticleSystem particleSystem, Transform effectsTransform)
        {
            _particleSystem = particleSystem;
            _effectsTransform = effectsTransform;
        }
        
        public void OnDestroy(Block entity, BlockDestroyContext destroyContext)
        {
            var particleSystem = Object.Instantiate(_particleSystem, _effectsTransform, true);
            var module = particleSystem.main;
            module.startColor = new ParticleSystem.MinMaxGradient(entity.BlockInfo.ParticleEffectColor);
            particleSystem.transform.position = entity.transform.position;
            particleSystem.Play();
            Object.Destroy(particleSystem.gameObject, particleSystem.main.duration + 1);
        }
    }
}