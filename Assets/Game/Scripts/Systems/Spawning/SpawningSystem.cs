﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Abstracts.Probabilities;
using Abstracts.Stages;
using Concrete.Factories.Blocks.Models;
using Configurations.Spawning;
using Spawning.Spawning.Difficulty;
using Spawning.Spawning.Packages;
using Spawning.Spawning.Spawners;
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
        private ISpawningDifficulty _defaultSpawningDifficulty;
        
        private Coroutine _spawnCoroutine;
        private Coroutine _changeDifficultyCoroutine;
        private int _defaultSpawnIteration;
        
        public void Initialize(ISpawningDifficulty spawningDifficulty,
            IPackageGenerator packageGenerator,
            IAbstractSpawner abstractSpawner)
        {
            _spawningDifficulty = spawningDifficulty;
            _abstractSpawner = abstractSpawner;
            _packageGenerator = packageGenerator;
            _defaultSpawningDifficulty = spawningDifficulty;
        }
        
        public void Enable() => _spawnCoroutine = StartCoroutine(Spawn());

        public void Disable()
        {
            if (_changeDifficultyCoroutine != null)
            {
                StopCoroutine(_changeDifficultyCoroutine);
                _spawningDifficulty = _defaultSpawningDifficulty;
            }
            StopCoroutine(_spawnCoroutine);
        }

        private IEnumerator Spawn(bool waitStartDelay = true, bool fromZero = false, bool increaseIterations = true)
        {
            if (waitStartDelay)
            {
                yield return new WaitForSeconds(_startDelay);
            }

            var spawnIteration = fromZero ? 0 : _defaultSpawnIteration;

            while (true)
            {
                var difficultyParameters = _spawningDifficulty.CalculateDifficultyInfo(spawnIteration);
                
                yield return SpawnPackage(difficultyParameters);
                
                yield return new WaitForSeconds(difficultyParameters.TimeToNextBlockPackage);
                
                spawnIteration++;
                
                if (increaseIterations)
                {
                    _defaultSpawnIteration++;
                }
            }
        }

        public void ChangeSpawnDifficulty(ISpawningDifficulty spawningDifficulty, float time)
        {
            if (_changeDifficultyCoroutine != null)
            {
                StopCoroutine(_changeDifficultyCoroutine);
            }
            
            _changeDifficultyCoroutine = StartCoroutine(ChangeDifficulty(spawningDifficulty, time));
        }

        private IEnumerator ChangeDifficulty(ISpawningDifficulty spawningDifficulty, float time)
        {
            _spawningDifficulty = spawningDifficulty;
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = StartCoroutine(Spawn(false, true, false));
            yield return new WaitForSeconds(time);
            _changeDifficultyCoroutine = null;
            StopCoroutine(_spawnCoroutine);
            _spawningDifficulty = _defaultSpawningDifficulty;
            _spawnCoroutine = StartCoroutine(Spawn());
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