using System.Collections;
using System.Collections.Generic;
using Abstracts.Factories;
using Abstracts.Probabilities;
using Concrete.Factories;
using Configurations;
using Entities.Base;
using Game.Scripts.Blocks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawning
{
    public class CuttableBlocksSpawningSystem : MonoBehaviour
    {
        [SerializeField] private SpawningSystemInfo _spawningSystemInfo;
        [SerializeField] private List<SpawnerInfo> _spawnerInfos;
        [SerializeField] private List<BlockInfo> _blockInfos;
        [SerializeField] private BlocksSystem _blocksSystem;
        
        private float _minIncreaseX = 3;
        private float _minIncreaseY = 5.5f;
        private float _maxIncreaseX = 10;
        private float _maxIncreaseY = 7.5f;

        private float _initialBlocksGravity = 3;

        private IFactory<BlockCreationContext, CuttableBlock> _blocksFactory;
        
        public void Initialize(IFactory<BlockCreationContext, CuttableBlock> blocksFactory)
        {
            _blocksFactory = blocksFactory;
        }

        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                yield return SpawnPackage(GetBlocksInPackageCount());
                yield return new WaitForSeconds(GetSpawnPackageInterval());
            }
        }

        private IEnumerator SpawnPackage(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var spawnerInfo = _spawnerInfos.GetRandomItemBasedOnProbabilities();

                var spawnedBlock = _blocksFactory.Create(new BlockCreationContext
                {
                    BlockInfo = GetRandomBlockInfo(),
                    Position = GetSpawnPoint(spawnerInfo),
                    InitialSpeed = GetInitialSpeed(spawnerInfo),
                    BlockGravity = _initialBlocksGravity
                });
                
                _blocksSystem.AddBlock(spawnedBlock);

                yield return new WaitForSeconds(GetSpawnBlockInPackageInterval());
            }
        }

        private int GetBlocksInPackageCount()
        {
            return _spawningSystemInfo.BlocksInPackage.Min;
        }

        private float GetSpawnBlockInPackageInterval()
        {
            return _spawningSystemInfo.SpawnBlockInPackageIntervals.Max;
        }
        
        private float GetSpawnPackageInterval()
        {
            return _spawningSystemInfo.SpawnPackageIntervals.Max;
        }

        private Vector3 GetSpawnPoint(SpawnerInfo spawnerInfo)
        {
            var randomNumber = Random.Range(0, 1f);
            return (1 - randomNumber) * spawnerInfo.FromPoint.position + randomNumber * spawnerInfo.ToPoint.position;
        }

        private BlockInfo GetRandomBlockInfo() => 
            _blockInfos[Random.Range(0, _blockInfos.Count - 1)];

        private Vector3 GetInitialSpeed(SpawnerInfo spawnerInfo) => 
            IncreaseInitialSpeed(GetSpeedDirection(spawnerInfo));

        private Vector3 GetSpeedDirection(SpawnerInfo spawnerInfo)
        {
            var angle = Random.Range(spawnerInfo.MinAngle, spawnerInfo.MaxAngle);
            var normal = (spawnerInfo.ToPoint.position - spawnerInfo.FromPoint.position).normalized;
            return Quaternion.Euler(0, 0, angle) * normal;
        }

        private Vector3 IncreaseInitialSpeed(Vector3 speedDirection)
        {
            var randomIncreaseX = Random.Range(_minIncreaseX, _maxIncreaseX);
            var randomIncreaseY = Random.Range(_minIncreaseY, _maxIncreaseY);
            return new Vector3(speedDirection.x * randomIncreaseX, speedDirection.y * randomIncreaseY);
        }
    }
}