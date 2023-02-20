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

        private static float _force;

        public void Initialize(BlocksSystem blocksSystem, Canvas canvas)
        {
            _blocksSystem = blocksSystem;
            _canvas = canvas;
        }
        
        public void Enable() { }

        public void Disable()
        {
            TryStopRoutine();
            SetGlobalForce(1);
            _canvas.gameObject.SetActive(false);
        }

        public void FreezeBlocks(float time, float force, float additionalVerticalSpeedWhenMovingUp)
        {
            TryStopRoutine();
            _force = force;
            _freezeCoroutine = StartCoroutine(Freeze(time, additionalVerticalSpeedWhenMovingUp));
        }

        private IEnumerator Freeze(float time, float additionalVerticalSpeedWhenMovingUp)
        {
            _canvas.gameObject.SetActive(true);
            Slow(GetAllBlocks(), _force);
            var currentTime = 0f;

            while (currentTime < time)
            {
                foreach (var block in GetAllBlocks())
                {
                    if (block.transform.position.y < 0 && block.GetSpeed().y > 0)
                    {
                        block.AddSpeed(new Vector3(0, additionalVerticalSpeedWhenMovingUp));
                    }   
                }
                
                currentTime += Time.fixedDeltaTime;
                yield return new WaitForSeconds(Time.fixedDeltaTime);
            }
            
            Accelerate(GetAllBlocks(), _force);
            SetGlobalForce(1);
            _canvas.gameObject.SetActive(false);
            _freezeCoroutine = null;
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
            foreach (var block in blocks)
            {
                block.SetGravityAcceleration(block.GetGravityAcceleration() * force);
                block.SetSpeed(block.GetSpeed() * force);
            }
        }

        private void SetGlobalForce(float force) => GlobalInitialForce.Value = force;

        private void TryStopRoutine()
        {
            if (_freezeCoroutine != null)
            {
                StopCoroutine(_freezeCoroutine);
                Accelerate(GetAllBlocks(), _force);
            }
        }

        private List<Block> GetAllBlocks() => _blocksSystem.AllBlocksOnField.ToList();
    }
}