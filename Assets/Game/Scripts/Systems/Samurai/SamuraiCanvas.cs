using System.Collections;
using Abstracts.Stages;
using UnityEngine;

namespace Systems.Samurai
{
    public class SamuraiCanvas : MonoBehaviour, IStageable
    {
        [SerializeField] private ParticleSystem _particleSystem;

        private Coroutine _showCoroutine;
        
        public void Enable() { }

        public void Disable()
        {
            if (_showCoroutine != null)
            {
                StopCoroutine(_showCoroutine);
                gameObject.SetActive(false);
            }
        }
        
        public void Show(float time)
        {
            gameObject.SetActive(true);
            _showCoroutine = StartCoroutine(ShowRoutine(time));
        }

        private IEnumerator ShowRoutine(float time)
        {
            _particleSystem.Play();
            yield return new WaitForSeconds(time);
            _particleSystem.Stop();
            gameObject.SetActive(false);
        }
    }
}