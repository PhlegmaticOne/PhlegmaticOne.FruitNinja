using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Helpers
{
    public class AnimatedCommandButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimatedCommandButtonAnimationParameters _animatedCommandButtonAnimationParameters;
        [SerializeField] private bool _resetOnAnimationEnded = true;
        private bool _isPlaying;
        private bool _isEnabled = true;
        private UnityAction _beforeAnimationAction;
        private UnityAction _afterAnimationAction;

        private void Start()
        {
            _button.onClick.AddListener(() =>
            {
                _beforeAnimationAction?.Invoke();
                Disable();
                _isPlaying = true;
                _animator.SetTrigger(_animatedCommandButtonAnimationParameters.PressedStateName);
            });
        }

        public void Disable()
        {
            _button.enabled = false;
            _isEnabled = false;
        }

        public void Enable()
        {
            _button.enabled = true;
            _isEnabled = true;
        }

        public void OnHighlighting()
        {
            if (_isPlaying == false && _isEnabled)
            {
                _animator.SetTrigger(_animatedCommandButtonAnimationParameters.HighlightedStateName);
            }
        }

        public void OnDehighlighting()
        {
            if (_isPlaying == false && _isEnabled)
            {
                ResetToNormal();
            }
        }

        public void OnBeforeAnimation(UnityAction beforeAnimationAction) => _beforeAnimationAction = beforeAnimationAction;

        public void OnAfterAnimation(UnityAction afterAnimationAction) => _afterAnimationAction = afterAnimationAction;

        public void OnAnimationEnded()
        {
            _isPlaying = false;
            _afterAnimationAction?.Invoke();

            if (_resetOnAnimationEnded)
            {
                ResetToNormal();
            }
        }

        private void ResetToNormal() => _animator.SetTrigger(_animatedCommandButtonAnimationParameters.NormalStateName);
    }

    [Serializable]
    public class AnimatedCommandButtonAnimationParameters
    {
        [SerializeField] private string _normalStateName = "Normal";
        [SerializeField] private string _hightlightedStateName = "Highlighted";
        [SerializeField] private string _pressedStateName = "Pressed";

        public string NormalStateName => _normalStateName;
        public string HighlightedStateName => _hightlightedStateName;
        public string PressedStateName => _pressedStateName;
    }
}