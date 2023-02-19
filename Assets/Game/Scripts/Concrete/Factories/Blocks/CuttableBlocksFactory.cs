using Abstracts.Animations;
using Abstracts.Factories;
using Concrete.Commands.BlockCommands.Base;
using Concrete.Factories.Blocks.Base;
using Concrete.Factories.Blocks.Models;
using Entities.Base;
using Spawning.Spawning.Commands;
using UnityEngine;

namespace Concrete.Factories.Blocks
{
    public static class GlobalInitialForce
    {
        public static float Value { get; set; } = 1f;
    }
    
    public class CuttableBlocksFactory : ICuttableBlocksFactory
    {
        private readonly CuttableBlock _prefab;
        private readonly IFactory<ITransformAnimation> _animationsFactory;
        private readonly Transform _parent;

        public CuttableBlocksFactory(Transform parent, CuttableBlock prefab,
            IFactory<ITransformAnimation> animationsFactory)
        {
            _parent = parent;
            _prefab = prefab;
            _animationsFactory = animationsFactory;
        }
        
        public CuttableBlock Create(BlockCreationContext creationContext)
        {
            var animation = _animationsFactory.Create();
            var block = Object.Instantiate(_prefab, _parent);
            block.transform.position = creationContext.Position;
            block.Initialize(creationContext.BlockInfo, animation);
            block.AddSpeed(creationContext.InitialSpeed / GlobalInitialForce.Value);
            block.SetGravityAcceleration(creationContext.BlockGravity / GlobalInitialForce.Value);
            return block;
        }
    }
}