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
        private const int ThrowPower = 3;

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

        public void Magnetize(Vector3 point, float time, float power, float radius, float magnetizedCenterRadius)
        {
            if (_magnetizeCoroutine != null)
            {
                return;
            }
            
            _magnetizeCoroutine = StartCoroutine(MagnetizeRoutine(point, time, power, radius, magnetizedCenterRadius));
        }

        private IEnumerator MagnetizeRoutine(Vector3 point, float time, float power, float radius, float magnetizedCenterRadius)
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
                    var direction = point - position;
                    var speedVector = direction.normalized * power;
                    block.DisableGravity();
                    block.SetSpeed(direction.magnitude <= magnetizedCenterRadius ? Vector3.zero : speedVector);
                }
                _magnetWaves.DrawLines(point, positions);
                
                yield return new WaitForFixedUpdate();
                currentTime += Time.fixedDeltaTime;
            }
            
            ResetGravities(point, radius);
            ThrowBlocksInRandomDirection(point, radius);
            _magnetWaves.Hide();
            _magnetizeCoroutine = null;
        }
        
        private void ThrowBlocksInRandomDirection(Vector3 point, float radius)
        {
            foreach (var block in _filteringBlocksSystem.MagnetizedBlocksInRadius(point, radius))
            {
                var angle = Random.Range(0, 360);
                var speed = Quaternion.Euler(0, 0, angle) * Vector3.right * ThrowPower;
                block.SetSpeed(speed);
            }
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