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
            _startGameButton.PointerDown += DisableButtons;
            _exitButton.PointerDown += DisableButtons;
        }

        public void OnStartGameClickExecuteCommand(ICommand command) => 
            _startGameButton.OnClick(command.Execute);

        public void OnExitButtonClickExecuteCommand(ICommand command) => 
            _exitButton.OnClick(command.Execute);

        private void DisableButtons()
        {
            _exitButton.Disable();
            _startGameButton.Disable();
            _canvasGroup.interactable = false;
        }
        
        
        private void EnableButtons()
        {
            _exitButton.Enable();
            _startGameButton.Enable();
            _canvasGroup.interactable = true;
        }
        
        
    }
}