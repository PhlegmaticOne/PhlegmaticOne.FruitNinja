using System;
using System.Collections.Generic;
using Abstracts.Animations;
using Abstracts.Commands;
using Abstracts.Factories;
using Abstracts.Initialization;
using Concrete.Animations;
using Concrete.Commands;
using Concrete.Factories.Animations;
using Concrete.Factories.Blocks;
using Entities.Base;
using Systems.Blocks;
using UnityEngine;

namespace Initialization.Factories
{
    public class FruitsFactoryInitializer : InitializerBase<IFactory<BlockCreationContext, CuttableBlock>>
    {
        [SerializeField] private UncuttableBlock _uncuttableBlock;
        [SerializeField] private ParticleSystem _juiceParticleSystem;
        [SerializeField] private Transform _blocksParent;
        [SerializeField] private Transform _effectsParent;
        [SerializeField] private CuttableBlock _prefab;
        [SerializeField] private BlocksSystem _blocksSystem;
        public override IFactory<BlockCreationContext, CuttableBlock> Create()
        {
            var animationsFactory = new AnimationsFactory(new List<Func<ITransformAnimation>>
            {
                () => new RotateAnimation(2),
                () => new ScaleAnimation(1.3f, 2)
            });
            
            var uncuttableBlockFactory = new UncuttableBlockFactory(_uncuttableBlock, _blocksParent);
            
            return new FruitsFactory(_blocksParent, _prefab, animationsFactory,
                new CompositeDestroyViewCommand(new List<IOnDestroyViewCommand<CuttableBlock, FruitDestroyContext>>()
                {
                    new FruitOnDestroyViewCommand(_juiceParticleSystem, _effectsParent),
                    new CutFruitIntoPartViewCommand(uncuttableBlockFactory, _blocksSystem)
                }));
        }
    }
}