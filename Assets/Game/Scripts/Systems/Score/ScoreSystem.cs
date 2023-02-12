using Abstracts.Data;
using Abstracts.Stages;
using Systems.Combos;
using Systems.Score.Models;
using UnityEngine;

namespace Systems.Score
{
    public class ScoreSystem : MonoBehaviour, IStageable
    {
        [SerializeField] private ScoreView _currentScoreView;
        [SerializeField] private ScoreView _maxScoreView;
        
        private IRepository<ScoreModel> _maxScoreRepository;
        private ScoreModel _currentMaxScore;
        private ScoreModel _currentScore;

        public void Initialize(IRepository<ScoreModel> maxScoreRepository) => _maxScoreRepository = maxScoreRepository;

        public int GameScore => _currentScore.Value;
        public int MaxScore => _currentMaxScore.Value;

        public void AddScorePoints(int scorePoints)
        {
            AddPoints(_currentScore, _currentScoreView, scorePoints);

            if (_currentScore.Value > _currentMaxScore.Value)
            {
                AddPoints(_currentMaxScore, _maxScoreView, scorePoints);
            }
        }

        private void AddPoints(ScoreModel scoreModel, ScoreView scoreView, int scorePointsToAdd)
        {
            scoreModel.AddScore(scorePointsToAdd);
            scoreView.SetScore(scoreModel.Value);
        }

        public void Enable()
        {
            _currentMaxScore = _maxScoreRepository.Get();
            _maxScoreView.SetScorePermanent(_currentMaxScore.Value);
            _currentScore = new ScoreModel(0);
            _currentScoreView.SetScorePermanent(_currentScore.Value);
        }

        public void Disable()
        {
            _maxScoreRepository.AddOrUpdate(_currentMaxScore);
        }
    }
}