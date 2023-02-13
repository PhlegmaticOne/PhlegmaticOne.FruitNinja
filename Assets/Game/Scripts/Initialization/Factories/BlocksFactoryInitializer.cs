using System.Collections.Generic;
using System.Linq;
using Abstracts.Animations;
using Abstracts.Initialization;
using Concrete.Commands.BlockCommands;
using Concrete.Commands.BlockCommands.Base;
using Concrete.Factories.Animations;
using Concrete.Factories.Blocks;
using Concrete.Factories.Blocks.Base;
using Entities.Base;
using UnityEngine;

namespace Initialization.Factories
{
    public class BlocksFactoryInitializer : InitializerBase<ICuttableBlocksFactory>
    {
        [SerializeField] 
        private List<InitializerBase<ICuttableBlockOnDestroyCommand>> _onDestroyViewCommands;
        [SerializeField] private List<InitializerBase<ITransformAnimation>> _transformAnimations;
        [SerializeField] private Transform _blocksTransform;
        [SerializeField] private CuttableBlock _prefab;
        
        public override ICuttableBlocksFactory Create()
        {
            var animationsFactory = new AnimationsFactory(_transformAnimations.Select(x => x.Create()));
            var onDestroyViewCommand = new CompositeDestroyViewCommand(_onDestroyViewCommands.Select(x => x.Create()).ToList());
            return new FruitBlocksFactory(_blocksTransform, _prefab, animationsFactory, onDestroyViewCommand);
        }
    }
}