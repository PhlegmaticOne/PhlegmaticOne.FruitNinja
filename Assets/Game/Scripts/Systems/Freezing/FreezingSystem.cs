using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Abstracts.Stages;
using Concrete.Factories.Blocks;
using Entities.Base;
using Systems.Blocks;
using UnityEngine;

namespace Systems.Freezing
{
    public class FreezingSystem : MonoBehaviour, IStageable
    {
        private BlocksSystem _blocksSystem;
        private Canvas _canvas;
        private Coroutine _freezeCoroutine;

        public void Initialize(BlocksSystem blocksSystem, Canvas canvas)
        {
            _blocksSystem = blocksSystem;
            _canvas = canvas;
        }
        
        public void Enable() { }

        public void Disable()
        {
            TryStopRoutine();
            _canvas.gameObject.SetActive(false);
        }

        public void FreezeBlocks(float time, float force)
        {
            TryStopRoutine();
            _freezeCoroutine = StartCoroutine(Freeze(time, force));
        }

        private IEnumerator Freeze(float time, float force)
        {
            _canvas.gameObject.SetActive(true);
            var all = _blocksSystem.AllBlocksOnField.ToList();
            Slow(all, force);
            yield return new WaitForSeconds(time);
            all = _blocksSystem.AllBlocksOnField.ToList();
            Accelerate(all, force);
            _canvas.gameObject.SetActive(false);
        }
        
        private void Slow(IReadOnlyList<Block> blocks, float force)
        {
            SetGlobalForce(force);
            foreach (var block in blocks)
            {
                block.SetGravityAcceleration(block.GetGravityAcceleration() / force);
                block.SetSpeed(block.GetSpeed() / force);
            }
        }
        
        private void Accelerate(IReadOnlyList<Block> blocks, float force)
        {
            SetGlobalForce(1);
            foreach (var block in blocks)
            {
                block.EnableDefaultGravity();
                block.SetSpeed(block.GetSpeed() * force);
            }
        }

        private void SetGlobalForce(float force) => GlobalInitialForce.Value = force;

        private void TryStopRoutine()
        {
            if (_freezeCoroutine != null)
            {
                StopCoroutine(_freezeCoroutine);
            }
        }
    }
}