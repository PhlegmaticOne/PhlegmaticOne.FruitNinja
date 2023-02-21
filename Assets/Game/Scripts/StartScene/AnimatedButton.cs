using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace StartScene
{
    public class AnimatedButton : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Button _button;
        [SerializeField] private EventTrigger _eventTrigger;

        public void OnPointerDown() => _animator.SetTrigger("Pressed");

        public void Disable() => _eventTrigger.enabled = false;

        public void Enable() => _eventTrigger.enabled = true;

        public void OnClickAnimationEnd() => OnPointerUp();

        public void OnPointerUp() => _animator.SetTrigger("Normal");

        public void OnClick(UnityAction action)
        {
            _button.onClick.AddListener(() =>
            {
                action?.Invoke();
            });
        }
    }
}