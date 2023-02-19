using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.BlockCommands.Models;
using Concrete.Factories.Blocks.Models;
using Entities.Base;
using Spawning.Spawning.Spawners;
using Systems.Follow;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Concrete.Commands.BlockCommands
{
    public class FollowInputCommand : ICuttableBlockOnDestroyCommand
    {
        private readonly FollowSystem _followSystem;
        private readonly IAbstractSpawner _abstractSpawner;

        public FollowInputCommand(FollowSystem followSystem, IAbstractSpawner abstractSpawner)
        {
            _followSystem = followSystem;
            _abstractSpawner = abstractSpawner;
        }
        
        public void OnDestroy(CuttableBlock entity, BlockDestroyContext destroyContext)
        {
            var clone = _abstractSpawner.Spawn(entity.BlockInfo, new BlockCreationContext
            {
                BlockInfo = entity.BlockInfo,
                Position = entity.transform.position,
                BlockGravity = 0,
                InitialSpeed = Vector2.zero
            });
            _followSystem.Follow(clone);
        }
    }
}