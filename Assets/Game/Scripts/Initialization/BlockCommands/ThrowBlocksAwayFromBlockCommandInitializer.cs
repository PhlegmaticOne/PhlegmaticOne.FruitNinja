using System;
using Abstracts.Initialization;
using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.ViewCommands;
using Systems.Blocks;
using UnityEngine;

namespace Initialization.BlockCommands
{
    public class ThrowBlocksAwayFromBlockCommandInitializer : InitializerBase<ICuttableBlockOnDestroyCommand>
    {
        [SerializeField] private BlocksSystem _blocksSystem;
        [SerializeField] private ExplosionParameters _explosionParameters;
        public override ICuttableBlockOnDestroyCommand Create() => 
            new ThrowBlocksAwayFromBlockCommand(_blocksSystem, _explosionParameters);
    }

    [Serializable]
    public class ExplosionParameters
    {
        [SerializeField] private float _explosionRadius;
        [SerializeField] private float _explosionPower;

        public float ExplosionRadius => _explosionRadius;
        public float ExplosionPower => _explosionPower;
    }
}