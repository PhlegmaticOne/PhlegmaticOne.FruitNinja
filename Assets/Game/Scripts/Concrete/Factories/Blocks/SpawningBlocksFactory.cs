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
    public class SpawningBlocksFactory : IBlocksFactory<BlockCreationContext>
    {
        private readonly Block _prefab;
        private readonly IFactory<ITransformAnimation> _animationsFactory;
        private readonly Transform _parent;

        public SpawningBlocksFactory(Transform parent, Block prefab,
            IFactory<ITransformAnimation> animationsFactory)
        {
            _parent = parent;
            _prefab = prefab;
            _animationsFactory = animationsFactory;
        }
        
        public Block Create(BlockCreationContext creationContext)
        {
            var animation = _animationsFactory.Create();
            var block = Object.Instantiate(_prefab, _parent);
            block.transform.position = creationContext.Position;
            block.Initialize(creationContext.BlockInfo, animation);
            block.AddSpeed(creationContext.InitialSpeed);
            block.SetGravityAcceleration(creationContext.BlockGravity);
            return block;
        }
    }
}