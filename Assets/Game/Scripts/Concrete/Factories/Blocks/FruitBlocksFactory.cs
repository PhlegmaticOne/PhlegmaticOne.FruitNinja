using Abstracts.Animations;
using Abstracts.Factories;
using Concrete.Commands.ModelCommands.Base;
using Concrete.Commands.ViewCommands.Base;
using Concrete.Factories.Blocks.Base;
using Concrete.Factories.Blocks.Models;
using Entities.Base;
using UnityEngine;

namespace Concrete.Factories.Blocks
{
    public class FruitBlocksFactory : ICuttableBlocksFactory
    {
        private readonly CuttableBlock _prefab;
        private readonly IFactory<ITransformAnimation> _animationsFactory;
        private readonly ICuttableBlockOnDestroyCommand _onDestroyCommand;
        private readonly ICuttableBlockOnDestroyViewCommand _onDestroyViewCommand;
        private readonly Transform _parent;

        public FruitBlocksFactory(Transform parent, 
            CuttableBlock prefab,
            IFactory<ITransformAnimation> animationsFactory,
            ICuttableBlockOnDestroyCommand onDestroyCommand,
            ICuttableBlockOnDestroyViewCommand onDestroyViewCommand)
        {
            _parent = parent;
            _prefab = prefab;
            _animationsFactory = animationsFactory;
            _onDestroyCommand = onDestroyCommand;
            _onDestroyViewCommand = onDestroyViewCommand;
        }
        
        public CuttableBlock Create(BlockCreationContext creationContext)
        {
            var animation = _animationsFactory.Create();
            var block = Object.Instantiate(_prefab, _parent);
            block.transform.position = creationContext.Position;
            block.Initialize(creationContext.BlockInfo, animation, _onDestroyCommand, _onDestroyViewCommand);
            block.AddSpeed(creationContext.InitialSpeed);
            block.SetGravityAcceleration(creationContext.BlockGravity);
            return block;
        }
    }
}