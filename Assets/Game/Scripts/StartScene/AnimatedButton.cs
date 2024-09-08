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
        [SerializeField] private bool _toNormalState = false;
        [SerializeField] private string _normalStateName = "Normal";
        [SerializeField] private string _pressedStateName = "Pressed";
        private UnityAction _action;

        public event UnityAction PointerDown;

        public void OnPointerDown()
        {
            _animator.SetTrigger(_pressedStateName);
            PointerDown?.Invoke();
        }
        public void OnPointerUp() => ToNormalState();

        public void OnPointerClick()
        {
            _action?.Invoke();
            if (_toNormalState)
            {
                ToNormalState();
            }
        }

        public void ToNormalState() => _animator.SetTrigger(_normalStateName);
        public void ToPressedState() => _animator.SetTrigger(_pressedStateName);

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