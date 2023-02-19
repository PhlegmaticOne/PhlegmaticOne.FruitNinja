using Abstracts.Commands;
using DG.Tweening;
using Helpers;
using TMPro;
using UnityEngine;

namespace Systems.Losing
{
    public class LosePopup : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private AppendTextMeshPro _maxScoreText;

        [SerializeField] private AnimatedCommandButton _restartCommandButton;
        [SerializeField] private AnimatedCommandButton _menuCommandButton;

        private float _fadeDuration;

        public void Initialize(float animationDuration, Camera cam,
            ICommand restartCommand, ICommand menuCommand)
        {
            _fadeDuration = animationDuration;
            OnRestartButtonClickedExecute(restartCommand);
            OnMenuButtonClickedExecute(menuCommand);
        }

        public void Show(int gameScore, int maxScore)
        {
            gameObject.SetActive(true);
            _scoreText.text = gameScore.ToString();
            _maxScoreText.SetText(maxScore.ToString());
            _canvasGroup.DOFade(1, _fadeDuration).OnComplete(EnableButtons);
        }

        public void OnRestartButtonClickedExecute(ICommand command)
        {
            _restartCommandButton.OnBeforeAnimation(DisableButtons);
            
            _restartCommandButton.OnAfterAnimation(() =>
            {
                _canvasGroup.DOFade(0, _fadeDuration)
                    .OnComplete(() =>
                    {
                        command.Execute();
                        gameObject.SetActive(false);
                    });
            });
        }

        public void OnMenuButtonClickedExecute(ICommand command)
        {
            _menuCommandButton.OnBeforeAnimation(DisableButtons);
            
            _menuCommandButton.OnAfterAnimation(() =>
            {
                gameObject.SetActive(false);
                command.Execute();
            });
        }

        private void DisableButtons()
        {
            _menuCommandButton.Disable();
            _restartCommandButton.Disable();
        }
        
        private void EnableButtons()
        {
            _menuCommandButton.Enable();
            _restartCommandButton.Enable();
        }
    }
}