using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class SceneTransition : MonoBehaviour
    {
        [SerializeField] private FadeAnimation _fadeAnimation;

        public void TransitToScene(int sceneIndex)
        {
            _fadeAnimation.Played += () => SceneManager.LoadScene(sceneIndex);
            _fadeAnimation.Fade();
        }
    }
}