using System.Collections;
using System.Collections.Generic;
using Abstracts.Stages;
using Systems.Blocks;
using UnityEngine;

namespace Systems.Magnet
{
    public class MagnetSystem : MonoBehaviour, IStageable
    {
        private FilteringBlocksSystem _filteringBlocksSystem;
        private MagnetWaves _magnetWaves;
        private Coroutine _magnetizeCoroutine;

        public void Initialize(FilteringBlocksSystem filteringBlocksSystem, MagnetWaves magnetWaves)
        {
            _filteringBlocksSystem = filteringBlocksSystem;
            _magnetWaves = magnetWaves;
        }
        
        public void Enable() { }

        public void Disable()
        {
            if (_magnetizeCoroutine != null)
            {
                _magnetWaves.Hide();
                StopCoroutine(_magnetizeCoroutine);
            }
        }

        public void Magnetize(Vector3 point, float time, float power, float radius)
        {
            if (_magnetizeCoroutine != null)
            {
                return;
            }
            
            _magnetizeCoroutine = StartCoroutine(MagnetizeRoutine(point, time, power, radius));
        }

        private IEnumerator MagnetizeRoutine(Vector3 point, float time, float power, float radius)
        {
            var currentTime = 0f;
            
            _magnetWaves.Show(point, radius);
            while (currentTime < time)
            {
                var positions = new List<Vector3>();
                foreach (var block in _filteringBlocksSystem.MagnetizedBlocksInRadius(point, radius))
                {
                    var position = block.transform.position;
                    positions.Add(position);
                    var direction = (point - position).normalized * power;
                    block.DisableGravity();
                    block.SetSpeed(direction);
                }
                _magnetWaves.DrawLines(point, positions);
                
                yield return new WaitForFixedUpdate();
                currentTime += Time.fixedDeltaTime;
            }
            
            ResetGravities(point, radius);
            _magnetWaves.Hide();
            _magnetizeCoroutine = null;
        }

        private void ResetGravities(Vector3 point, float radius)
        {
            foreach (var block in _filteringBlocksSystem.MagnetizedBlocksInRadius(point, radius))
            {
                block.EnableDefaultGravity();
            }
        }
    }
}