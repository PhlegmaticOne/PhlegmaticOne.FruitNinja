using System.Collections;
using System.Collections.Generic;
using Abstracts.Probabilities;
using Abstracts.Stages;
using Concrete.Factories.Blocks.Models;
using Configurations;
using Spawning.Spawning.Difficulty;
using Spawning.Spawning.Packages;
using Spawning.Spawning.Spawners;
using Spawning.Spawning.SpawnPolicies;
using Systems.Blocks;
using UnityEngine;

namespace Spawning.Spawning
{
    public class SpawningSystem : MonoBehaviour, IStageable
    {
        [SerializeField] private float _startDelay;
        [SerializeField] private BlocksSystem _blocksSystem;
        [SerializeField] private List<SpawnerInfo> _spawnerInfos;
        
        private ISpawningDifficulty _spawningDifficulty;
        private IAbstractSpawner _abstractSpawner;
        private IPackageGenerator _packageGenerator;
        
        private Coroutine _spawnCoroutine;
        
        public void Initialize(ISpawningDifficulty spawningDifficulty,
            IPackageGenerator packageGenerator,
            IAbstractSpawner abstractSpawner)
        {
            _spawningDifficulty = spawningDifficulty;
            _abstractSpawner = abstractSpawner;
            _packageGenerator = packageGenerator;
        }
        
        public void Enable() => _spawnCoroutine = StartCoroutine(Spawn());
        
        public void Disable() => StopCoroutine(_spawnCoroutine);

        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(_startDelay);
            var spawnIterations = 0;
            while (true)
            {
                var difficultyParameters = _spawningDifficulty.CalculateDifficultyInfo(spawnIterations);
                
                yield return SpawnPackage(difficultyParameters);
                
                yield return new WaitForSeconds(difficultyParameters.TimeToNextBlockPackage);
                
                spawnIterations++;
            }
        }

        private IEnumerator SpawnPackage(DifficultyInfo difficultyInfo)
        {
            foreach (var packageEntry in _packageGenerator.GeneratePackage(difficultyInfo))
            {
                var blockInfo = packageEntry.BlockInfo;

                var spawnerInfo = _spawnerInfos.GetRandomItemBasedOnProbabilities();
                
                var spawnedBlock = _abstractSpawner.Spawn(blockInfo, new BlockCreationContext
                {
                    BlockInfo = blockInfo,
                    Position = GetSpawnPoint(spawnerInfo),
                    InitialSpeed = GetInitialSpeed(spawnerInfo),
                    BlockGravity = difficultyInfo.BlocksGravity
                });
                
                _blocksSystem.AddBlock(spawnedBlock);

                yield return new WaitForSeconds(packageEntry.TimeToNextBlock);
            }
        }

        private Vector3 GetSpawnPoint(SpawnerInfo spawnerInfo)
        {
            var randomNumber = Random.Range(0, 1f);
            return (1 - randomNumber) * spawnerInfo.FromPoint.position + randomNumber * spawnerInfo.ToPoint.position;
        }
        
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