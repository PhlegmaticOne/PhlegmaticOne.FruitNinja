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

        private bool _isPlaying;
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
        }

        public void Enable()
        {
            _button.enabled = true;
        }

        public void OnHighlighting()
        {
            if (_isPlaying == false && _button.enabled)
            {
                _animator.SetTrigger(_animatedCommandButtonAnimationParameters.HighlightedStateName);
            }
        }

        public void OnDehighlighting()
        {
            if (_isPlaying == false)
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
            ResetToNormal();
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