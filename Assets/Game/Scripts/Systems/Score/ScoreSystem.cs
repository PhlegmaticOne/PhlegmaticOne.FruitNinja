using Abstracts.Data;
using Systems.Score.Models;
using UnityEngine;

namespace Systems.Score
{
    public class ScoreSystem : MonoBehaviour
    {
        [SerializeField] private ScoreView _currentScoreView;
        [SerializeField] private ScoreView _maxScoreView;

        private IRepository<ScoreModel> _maxScoreRepository;
        private ScoreModel _currentMaxScore;
        private ScoreModel _currentScore;

        public void Initialize(IRepository<ScoreModel> maxScoreRepository)
        {
            _maxScoreRepository = maxScoreRepository;
            _currentMaxScore = maxScoreRepository.Get();
            _currentScore = new ScoreModel(0);
        }

        public void AddScorePoints(int scorePoints)
        {
            AddPoints(_currentScore, _currentScoreView, scorePoints);

            if (_currentScore.Value > _currentMaxScore.Value)
            {
                AddPoints(_currentMaxScore, _maxScoreView, scorePoints);
                _maxScoreRepository.AddOrUpdate(_currentMaxScore);
            }
        }

        private void AddPoints(ScoreModel scoreModel, ScoreView scoreView, int scorePointsToAdd)
        {
            scoreModel.AddScore(scorePointsToAdd);
            scoreView.SetScore(scoreModel.Value);
        }
    }
}