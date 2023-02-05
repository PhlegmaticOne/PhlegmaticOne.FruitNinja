using Abstracts.Animations;
using Abstracts.Commands;
using Abstracts.Factories;
using Concrete.Commands;
using Entities.Base;
using UnityEngine;

namespace Concrete.Factories.Blocks
{
    public class FruitsFactory : IFactory<BlockCreationContext, CuttableBlock>
    {
        private readonly CuttableBlock _prefab;
        private readonly IFactory<ITransformAnimation> _animationsFactory;
        private readonly IOnDestroyViewCommand<CuttableBlock, FruitDestroyContext> _onDestroyViewCommand;
        private readonly Transform _parent;

        public FruitsFactory(Transform parent, 
            CuttableBlock prefab,
            IFactory<ITransformAnimation> animationsFactory,
            IOnDestroyViewCommand<CuttableBlock, FruitDestroyContext> onDestroyViewCommand)
        {
            _parent = parent;
            _prefab = prefab;
            _animationsFactory = animationsFactory;
            _onDestroyViewCommand = onDestroyViewCommand;
        }
        
        public CuttableBlock Create(BlockCreationContext creationContext)
        {
            var animation = _animationsFactory.Create();
            var block = Object.Instantiate(_prefab, _parent);
            block.transform.position = creationContext.Position;
            block.Initialize(creationContext.BlockInfo, animation, _onDestroyViewCommand);
            block.AddSpeed(creationContext.InitialSpeed);
            block.SetGravityAcceleration(creationContext.BlockGravity);
            return block;
        }
    }
}