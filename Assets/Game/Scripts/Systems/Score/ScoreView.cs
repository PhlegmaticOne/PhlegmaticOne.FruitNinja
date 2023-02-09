using System.Collections;
using TMPro;
using UnityEngine;

namespace Systems.Score
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private float _updateScoreDuration;
        private float _previousScore;
        private int _currentScore;

        private Coroutine UpdateScoreCoroutine;
        
        public void SetScore(int score)
        {
            if (UpdateScoreCoroutine != null)
            {
                StopCoroutine(UpdateScoreCoroutine);
            }

            _currentScore = score;
            UpdateScoreCoroutine = StartCoroutine(UpdateScore());
        }

        public void SetScorePermanent(int score)
        {
            _scoreText.text = score.ToString();
            _currentScore = score;
            _previousScore = score;
        }

        private IEnumerator UpdateScore()
        {
            var fps = 1.0f / Time.deltaTime;
            var step = (_currentScore - _previousScore) / (fps * _updateScoreDuration);
            
            while(_previousScore < _currentScore)
            {
                _previousScore += step;
                if (_previousScore > _currentScore)
                {
                    _previousScore = _currentScore;
                }

                _scoreText.SetText(((int)_previousScore).ToString());

                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
    }
}