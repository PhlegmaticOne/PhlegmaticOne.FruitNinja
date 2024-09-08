using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Abstracts.Extensions;
using Abstracts.Stages;
using Concrete.Factories.Blocks.Models;
using Entities;
using Entities.Base;
using Spawning.Spawning.Spawners;
using Spawning.Spawning.SpawnPolicies;
using Systems.Blocks;
using Systems.Cutting;
using UnityEngine;

namespace Systems.Metamorphic
{
    public class MetamorphicSystem : MonoBehaviour, IStageable
    {
        private readonly Dictionary<MetamorphicBlock, Coroutine> _coroutines = 
            new Dictionary<MetamorphicBlock, Coroutine>();
        
        private BlocksSystem _blocksSystem;
        private StateCheckingBlocksSystem _stateCheckingBlocksSystem;
        private CuttingSystem _cuttingSystem;
        private IAbstractSpawner _abstractSpawner;
        private ISpawnPoliciesProvider _spawnPoliciesProvider;
        public void Initialize(BlocksSystem blocksSystem, 
            StateCheckingBlocksSystem stateCheckingBlocksSystem,
            CuttingSystem cuttingSystem,
            IAbstractSpawner abstractSpawner, 
            ISpawnPoliciesProvider spawnPoliciesProvider)
        {
            _blocksSystem = blocksSystem;
            _abstractSpawner = abstractSpawner;
            _spawnPoliciesProvider = spawnPoliciesProvider;
            _stateCheckingBlocksSystem = stateCheckingBlocksSystem;
            _cuttingSystem = cuttingSystem;
            
            _stateCheckingBlocksSystem.BlockFallen += StateCheckingBlocksSystemOnBlockFallen;
            _cuttingSystem.Cut += OnCut;
            _blocksSystem.BlockAdded += BlocksSystemOnBlockAdded;
        }

        private void OnCut(Block block) => TryStopRoutineForBlock(block, true);
        private void StateCheckingBlocksSystemOnBlockFallen(Block block) => TryStopRoutineForBlock(block, false);

        private void TryStopRoutineForBlock(Block block, bool stopAnimation)
        {
            foreach (var keyValuePair in _coroutines)
            {
                var metamorphicBlock = keyValuePair.Key;
                if (metamorphicBlock.CurrentlyMorphedTo == block)
                {
                    if (stopAnimation)
                    {
                        metamorphicBlock.Stop();
                    }
                    Stop(metamorphicBlock);
                    _coroutines.Remove(metamorphicBlock);
                    break;
                }
            }
        }

        private void BlocksSystemOnBlockAdded(Block block)
        {
            if (block is MetamorphicBlock metamorphic)
            {
                var routine = StartCoroutine(MetamorphicRoutine(metamorphic));
                _coroutines.Add(metamorphic, routine);
            }
        }

        private IEnumerator MetamorphicRoutine(MetamorphicBlock metamorphicBlock)
        {
            while (true)
            {
                var newBlock = SpawnMorphBlock(metamorphicBlock);

                if (newBlock == null)
                {
                    break;
                }

                if (metamorphicBlock.CurrentlyMorphedTo != null)
                {
                    _blocksSystem.RemoveBlock(metamorphicBlock.CurrentlyMorphedTo);
                }

                metamorphicBlock.MorphTo(newBlock);
                yield return new WaitForSeconds(metamorphicBlock.TransformPeriod);
            }
        }

        public void Enable() { }

        public void Disable()
        {
            foreach (var coroutine in _coroutines)
            {
                Stop(coroutine.Key);
            }
            _coroutines.Clear();
        }

        private Block SpawnMorphBlock(MetamorphicBlock metamorphicBlock)
        {
            try
            {
                var random = metamorphicBlock.CanTransformTo
                    .Where(x => _spawnPoliciesProvider.CanSpawn(x))
                    .ToList()
                    .RandomItem();
            
                var newBlock = _abstractSpawner.Spawn(random, new BlockCreationContext
                {
                    BlockInfo = random,
                    Position = metamorphicBlock.transform.position,
                    BlockGravity = metamorphicBlock.GetGravityAcceleration(),
                    InitialSpeed = metamorphicBlock.GetSpeed(),
                    WithAnimations = false
                });
            
                _blocksSystem.AddBlock(newBlock);
                return newBlock;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void Stop(MetamorphicBlock metamorphicBlock)
        {
            var routine = _coroutines[metamorphicBlock];
            StopCoroutine(routine);
        }
    }
}