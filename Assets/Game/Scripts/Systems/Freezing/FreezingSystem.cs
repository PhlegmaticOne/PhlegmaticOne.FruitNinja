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
        private Canvas _canvas;
        private Coroutine _freezeCoroutine;

        private static float _force;

        public void Initialize(Canvas canvas) => _canvas = canvas;

        public void Enable() { }

        public void Disable()
        {
            TryStopRoutine();
            _canvas.gameObject.SetActive(false);
        }

        public void FreezeBlocks(float time, float force)
        {
            TryStopRoutine();
            _force = force;
            _freezeCoroutine = StartCoroutine(Freeze(time));
        }

        private IEnumerator Freeze(float time)
        {
            _canvas.gameObject.SetActive(true);
            SetTimeScale(1f / _force);
            yield return new WaitForSeconds(time / _force);
            SetTimeScale(1f);
            _canvas.gameObject.SetActive(false);
            _freezeCoroutine = null;
        }

        private void SetTimeScale(float scale)
        {
            Time.timeScale = scale;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }

        private void TryStopRoutine()
        {
            if (_freezeCoroutine != null)
            {
                StopCoroutine(_freezeCoroutine);
            }
        }
    }
}