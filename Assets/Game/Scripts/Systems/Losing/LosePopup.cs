using Abstracts.Commands;
using DG.Tweening;
using Helpers;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Button = UnityEngine.UI.Button;

namespace Systems.Losing
{
    public class LosePopup : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _fadeDuration;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private AppendTextMeshPro _maxScoreText;

        [SerializeField] private AnimatedCommandButton _restartCommandButton;
        [SerializeField] private AnimatedCommandButton _menuCommandButton;
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