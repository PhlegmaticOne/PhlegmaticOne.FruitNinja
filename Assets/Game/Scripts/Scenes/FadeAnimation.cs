using UnityEngine;
using UnityEngine.Events;

namespace Scenes
{
    public class FadeAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _triggerName;
        [SerializeField] private float _animationTime;
        public float AnimationTime => _animationTime;
        public event UnityAction Played;
        
        public void Fade() => _animator.SetTrigger(_triggerName);
        public void OnPlayed() => Played?.Invoke();
    }
}