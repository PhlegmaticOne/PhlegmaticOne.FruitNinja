using Abstracts.Commands;
using Abstracts.Data;
using Systems.Score.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StartScene
{
    public class StartScenePopup : MonoBehaviour
    {
        [SerializeField] private AnimatedButton _startGameButton;
        [SerializeField] private AnimatedButton _exitButton;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private CanvasGroup _canvasGroup;

        public void Initialize(IRepository<ScoreModel> scoreRepository)
        {
            _scoreText.text = scoreRepository.Get().Value.ToString();
        }

        public void OnStartGameClickExecuteCommand(ICommand command) => 
            _startGameButton.OnClick(() =>
            {
                DisableButtons();
                command.Execute();
            });

        public void OnExitButtonClickExecuteCommand(ICommand command) => 
            _exitButton.OnClick(() =>
            {
                DisableButtons();
                command.Execute();
            });

        private void DisableButtons()
        {
            _exitButton.Disable();
            _startGameButton.Disable();
            _canvasGroup.interactable = false;
        }
    }
}