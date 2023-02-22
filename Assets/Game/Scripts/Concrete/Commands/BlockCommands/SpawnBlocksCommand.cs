using System.Collections.Generic;
using Abstracts.Extensions;
using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.BlockCommands.Models;
using Concrete.Factories.Blocks;
using Concrete.Factories.Blocks.Models;
using Configurations;
using Configurations.Base;
using Entities.Base;
using Spawning.Spawning.Spawners;
using Systems.Blocks;
using Systems.Cutting;
using UnityEngine;

namespace Concrete.Commands.BlockCommands
{
    public class SpawnBlocksCommand : IBlockOnDestroyCommand
    {
        private const float HalfCircle = 180f;
        private const float AngleOffset = 40f;
        private readonly List<BlockInfo> _possibleBlocks;
        private readonly MinMaxInfo<int> _blockCount;
        private readonly float _explosionPower;
        private readonly float _delayAfterSlicing;
        private readonly IAbstractSpawner _abstractSpawner;
        private readonly BlocksSystem _blocksSystem;
        private readonly CuttingSystem _cuttingSystem;
        
        public SpawnBlocksCommand(List<BlockInfo> possibleBlocks, 
            MinMaxInfo<int> blockCount,
            float explosionPower,
            float delayAfterSlicing,
            IAbstractSpawner abstractSpawner, 
            BlocksSystem blocksSystem,
            CuttingSystem cuttingSystem)
        {
            _possibleBlocks = possibleBlocks;
            _blockCount = blockCount;
            _explosionPower = explosionPower;
            _delayAfterSlicing = delayAfterSlicing;
            _abstractSpawner = abstractSpawner;
            _blocksSystem = blocksSystem;
            _cuttingSystem = cuttingSystem;
        }
        
        public void OnDestroy(Block entity, BlockDestroyContext destroyContext)
        {
            var blocksCount = GetBlocksCount();
            var deltaAngle = CalculateDeltaAngle(blocksCount);
            var currentAngle = AngleOffset + deltaAngle;

            for (var i = 0; i < blocksCount; i++)
            {
                var blockInfo = _possibleBlocks.RandomItem();
                var speed = CalculateSpeedForDirection(currentAngle);
                
                var block = _abstractSpawner.Spawn(blockInfo, new BlockCreationContext
                {
                    BlockInfo = blockInfo,
                    Position = entity.transform.position,
                    BlockGravity = entity.GetGravityAcceleration(),
                    InitialSpeed = speed
                });
                
                _blocksSystem.AddBlock(block);

                currentAngle += deltaAngle;
            }
            
            _cuttingSystem.DisableCutting(_delayAfterSlicing);
        }

        private int GetBlocksCount() => Random.Range(_blockCount.Min, _blockCount.Max + 1);

        private static float CalculateDeltaAngle(int blocksCount) =>
            (HalfCircle - 2 * AngleOffset) / (blocksCount + 1);

        private Vector3 CalculateSpeedForDirection(float angle) =>
            Quaternion.Euler(0, 0, angle) * Vector3.right * _explosionPower;
    }
}