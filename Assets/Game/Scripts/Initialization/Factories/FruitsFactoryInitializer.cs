using System.Collections.Generic;
using System.Linq;
using Abstracts.Animations;
using Abstracts.Initialization;
using Concrete.Commands.ModelCommands;
using Concrete.Commands.ModelCommands.Base;
using Concrete.Commands.ViewCommands;
using Concrete.Commands.ViewCommands.Base;
using Concrete.Factories.Animations;
using Concrete.Factories.Blocks;
using Concrete.Factories.Blocks.Base;
using Entities.Base;
using UnityEngine;

namespace Initialization.Factories
{
    public class FruitsFactoryInitializer : InitializerBase<ICuttableBlocksFactory>
    {
        [SerializeField] 
        private List<InitializerBase<ICuttableBlockOnDestroyViewCommand>> _onDestroyViewCommands;
        [SerializeField] 
        private List<InitializerBase<ICuttableBlockOnDestroyCommand>> _onDestroyCommands;
        [SerializeField] private List<InitializerBase<ITransformAnimation>> _transformAnimations;
        [SerializeField] private Transform _blocksTransform;
        [SerializeField] private CuttableBlock _prefab;
        
        public override ICuttableBlocksFactory Create()
        {
            var animationsFactory = new AnimationsFactory(_transformAnimations.Select(x => x.Create()));
            var onDestroyCommand = new CompositeOnDestroyCommand(_onDestroyCommands.Select(x => x.Create()).ToList());
            var onDestroyViewCommand = new CompositeDestroyViewCommand(_onDestroyViewCommands.Select(x => x.Create()).ToList());
            return new FruitBlocksFactory(_blocksTransform, _prefab, animationsFactory, onDestroyCommand, onDestroyViewCommand);
        }
    }
}