using TMPro;
using UnityEngine;

namespace Systems.Score
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        private int _currentScore;
        private void Start()
        {
            _currentScore = 0;
            UpdateScoreText(_currentScore);
        }

        public void SetScore(int score) => UpdateScoreText(score);
        private void UpdateScoreText(int value) => _scoreText.text = value.ToString();
    }
}