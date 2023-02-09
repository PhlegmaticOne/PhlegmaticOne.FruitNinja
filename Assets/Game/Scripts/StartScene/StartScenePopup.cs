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
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private TextMeshProUGUI _scoreText;

        public void Initialize(IRepository<ScoreModel> scoreRepository)
        {
            _scoreText.text = scoreRepository.Get().Value.ToString();
        }

        public void OnStartGameClickExecuteCommand(ICommand command)
        {
            _startGameButton.onClick.AddListener(command.Execute);
        }

        public void OnExitButtonClickExecuteCommand(ICommand command)
        {
            _exitButton.onClick.AddListener(command.Execute);
        }
    }
}