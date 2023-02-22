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
        private UnityAction _action;

        public event UnityAction PointerDown;

        public void OnPointerDown()
        {
            _animator.SetTrigger("Pressed");
            PointerDown?.Invoke();
        }
        public void OnPointerUp() => _animator.SetTrigger("Normal");

        public void OnPointerClick() => _action?.Invoke();

        public void Disable()
        {
            _button.enabled = false;
            _button.interactable = false;
            _eventTrigger.enabled = false;
        }

        public void Enable()
        {
            _button.enabled = true;
            _button.interactable = true;
            _eventTrigger.enabled = true;
        }

        public void OnClickAnimationEnd() => OnPointerClick();

        public void OnClick(UnityAction action) => _action = action;
    }
}