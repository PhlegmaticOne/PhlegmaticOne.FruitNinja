using Abstracts.Data;
using Systems.Score.Models;

namespace Game.Scripts.Concrete.Data
{
    public class InMemoryMaxScoreRepository : IRepository<ScoreModel>
    {
        private ScoreModel _scoreModel = new ScoreModel(0);
        public void AddOrUpdate(ScoreModel item) => _scoreModel = item;
        public ScoreModel Get() => _scoreModel;
    }
}