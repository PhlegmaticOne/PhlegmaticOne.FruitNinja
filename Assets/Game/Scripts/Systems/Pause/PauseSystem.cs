using Abstracts.Stages;
using StartScene;
using UnityEngine;

namespace Systems.Pause
{
    public class PauseSystem : MonoBehaviour, IStageable
    {
        private AnimatedButton _pauseButton;
        private PausePopup _pausePopup;

        public void Initialize(AnimatedButton pauseButton, PausePopup pausePopup)
        {
            _pauseButton = pauseButton;
            _pausePopup = pausePopup; 
            _pauseButton.PointerDown += () => _pauseButton.Disable();
            _pauseButton.OnClick(() => _pausePopup.Show());
        }
        
        public void Enable()
        {
            _pauseButton.Enable();
            _pauseButton.ToNormalState();
        }

        public void Disable()
        {
            _pauseButton.Disable();
        }
    }
}