using UnityEngine;

namespace Scenes
{
    public class FadeAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _triggerName;
        [SerializeField] private float _animationTime;

        public float AnimationTime => _animationTime;
        
        public void Fade() => _animator.SetTrigger(_triggerName);
    }
}