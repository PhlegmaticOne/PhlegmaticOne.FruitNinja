using System.Collections;
using System.Collections.Generic;
using Abstracts.Probabilities;
using Abstracts.Stages;
using Concrete.Factories.Blocks.Base;
using Concrete.Factories.Blocks.Models;
using Configurations;
using Spawning.Spawning.Difficulty;
using Systems.Blocks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawning.Spawning
{
    public class CuttableBlocksSpawningSystem : MonoBehaviour, IStageable
    {
        [SerializeField] private BlocksSystem _blocksSystem;
        [SerializeField] private SpawningSystemInfo _spawningSystemInfo;
        [SerializeField] private List<BlockInfo> _blockInfos;
        [SerializeField] private List<SpawnerInfo> _spawnerInfos;

        private ICuttableBlocksFactory _blocksFactory;
        private ISpawningDifficulty _spawningDifficulty;

        private Coroutine _spawnCoroutine;
        
        public void Initialize(ICuttableBlocksFactory blocksFactory, ISpawningDifficulty spawningDifficulty)
        {
            _blocksFactory = blocksFactory;
            _spawningDifficulty = spawningDifficulty;
        }
        
        public void Enable() => _spawnCoroutine = StartCoroutine(Spawn());
        public void Disable() => StopCoroutine(_spawnCoroutine);

        private IEnumerator Spawn()
        {
            var spawnIterations = 0;
            while (true)
            {
                var difficultyParameters =
                    _spawningDifficulty.CalculateDifficultyInfo(spawnIterations, _spawningSystemInfo);
                
                yield return SpawnPackage(difficultyParameters);
                yield return new WaitForSeconds(difficultyParameters.TimeToNextBlockPackage);
                
                spawnIterations++;
            }
        }

        private IEnumerator SpawnPackage(DifficultyInfo difficultyInfo)
        {
            for (var i = 0; i < difficultyInfo.BlocksInPackageCount; i++)
            {
                var spawnerInfo = _spawnerInfos.GetRandomItemBasedOnProbabilities();

                var spawnedBlock = _blocksFactory.Create(new BlockCreationContext
                {
                    BlockInfo = GetRandomBlockInfo(),
                    Position = GetSpawnPoint(spawnerInfo),
                    InitialSpeed = GetInitialSpeed(spawnerInfo),
                    BlockGravity = difficultyInfo.BlocksGravity
                });
                
                _blocksSystem.AddBlock(spawnedBlock);

                yield return new WaitForSeconds(GetSpawnBlockInPackageInterval());
            }
        }

        private float GetSpawnBlockInPackageInterval()
        {
            return Random.Range(
                _spawningSystemInfo.SpawnBlockInPackageIntervals.Min,
                _spawningSystemInfo.SpawnBlockInPackageIntervals.Max);
        }

        private Vector3 GetSpawnPoint(SpawnerInfo spawnerInfo)
        {
            var randomNumber = Random.Range(0, 1f);
            return (1 - randomNumber) * spawnerInfo.FromPoint.position + randomNumber * spawnerInfo.ToPoint.position;
        }

        private BlockInfo GetRandomBlockInfo() => 
            _blockInfos[Random.Range(0, _blockInfos.Count - 1)];

        private Vector3 GetInitialSpeed(SpawnerInfo spawnerInfo) => 
            IncreaseInitialSpeed(GetSpeedDirection(spawnerInfo), spawnerInfo);

        private Vector3 GetSpeedDirection(SpawnerInfo spawnerInfo)
        {
            var angle = Random.Range(spawnerInfo.AnglesRange.Min, spawnerInfo.AnglesRange.Max);
            var normal = (spawnerInfo.ToPoint.position - spawnerInfo.FromPoint.position).normalized;
            return Quaternion.Euler(0, 0, angle) * normal;
        }

        private Vector3 IncreaseInitialSpeed(Vector3 speedDirection, SpawnerInfo spawnerInfo)
        {
            var randomIncreaseX = Random.Range(
                spawnerInfo.InitialSpeedMultiplierRangeX.Min,
                spawnerInfo.InitialSpeedMultiplierRangeX.Max);
            var randomIncreaseY = Random.Range(
                spawnerInfo.InitialSpeedMultiplierRangeY.Min, 
                spawnerInfo.InitialSpeedMultiplierRangeY.Max);
            return new Vector3(speedDirection.x * randomIncreaseX, speedDirection.y * randomIncreaseY);
        }
    }
}