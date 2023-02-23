using Abstracts.Commands;
using DG.Tweening;
using StartScene;
using UnityEngine;

namespace Systems.Pause
{
    public class PausePopup : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private AnimatedButton _continueGameButton;
        [SerializeField] private AnimatedButton _menuButton;
        private float _fadeDuration;

        private float _entryTimeScale;

        public void Initialize(ICommand menuCommand, ICommand continueCommand, float fadeDuration)
        {
            _fadeDuration = fadeDuration;
            _continueGameButton.PointerDown += DisableButtons;
            _menuButton.PointerDown += DisableButtons;
            
            _continueGameButton.OnClick(() =>
            {
                DisableButtons();
                Hide();
                continueCommand.Execute();
            });
            
            _menuButton.OnClick(() =>
            {
                DisableButtons();
                menuCommand.Execute();
            });
        }

        public void Show()
        {
            _entryTimeScale = Time.timeScale;
            SetTimeScale(0f);
            gameObject.SetActive(true);
            _canvasGroup.DOFade(1f, _fadeDuration)
                .SetUpdate(true)
                .OnComplete(EnableButtons);
        }

        private void Hide()
        {
            _canvasGroup.DOFade(0f, _fadeDuration)
                .SetUpdate(true)
                .OnComplete(() =>
                {
                    SetTimeScale(_entryTimeScale);
                    gameObject.SetActive(false);
                });
        }
        
        private void SetTimeScale(float scale)
        {
            Time.timeScale = scale;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }

        private void DisableButtons()
        {
            _menuButton.Disable();
            _continueGameButton.Disable();
            _canvasGroup.interactable = false;
        }

        private void EnableButtons()
        {
            _menuButton.Enable();
            _continueGameButton.Enable();
            _canvasGroup.interactable = true;
        }
    }
}