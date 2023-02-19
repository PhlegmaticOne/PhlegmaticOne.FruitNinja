using System.Collections;
using UnityEngine;

namespace Systems.Samurai
{
    public class SamuraiCanvas : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        
        public void Show(float time)
        {
            gameObject.SetActive(true);
            StartCoroutine(ShowRoutine(time));
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