using Abstracts.Commands;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;

namespace Systems.Losing
{
    public class LosePopup : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _fadeDuration;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private PretextTextMeshPro _maxScoreText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _menuButton;
        public void Show(int gameScore, int maxScore)
        {
            gameObject.SetActive(true);
            _scoreText.text = gameScore.ToString();
            _maxScoreText.SetText(maxScore.ToString());
            _canvasGroup.DOFade(1, _fadeDuration).OnComplete(() => SetButtonsInteractable(true));
        }

        public void OnRestartButtonClickedExecute(ICommand command)
        {
            _restartButton.onClick.AddListener(() =>
            {
                _canvasGroup.DOFade(0, _fadeDuration)
                    .OnComplete(() =>
                    {
                        SetButtonsInteractable(false);
                        gameObject.SetActive(false);
                        command.Execute();
                    });
            });
        }

        public void OnMenuButtonClickedExecute(ICommand command) => _menuButton.onClick.AddListener(command.Execute);

        private void SetButtonsInteractable(bool interactable)
        {
            _restartButton.interactable = interactable;
            _menuButton.interactable = interactable;
        }
    }
}