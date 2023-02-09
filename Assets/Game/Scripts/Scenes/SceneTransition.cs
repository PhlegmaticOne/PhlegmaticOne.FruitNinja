using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class SceneTransition : MonoBehaviour
    {
        [SerializeField] private FadeAnimation _fadeAnimation;
        public void TransitToScene(int sceneIndex) => StartCoroutine(Transit(sceneIndex));

        private IEnumerator Transit(int sceneIndex)
        {
            _fadeAnimation.Fade();
            yield return new WaitForSeconds(_fadeAnimation.AnimationTime);
            SceneManager.LoadScene(sceneIndex);
        }
    }
}