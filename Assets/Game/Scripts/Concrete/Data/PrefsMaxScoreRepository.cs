using Abstracts.Data;
using Systems.Score.Models;
using UnityEngine;

namespace Concrete.Data
{
    public class PrefsMaxScoreRepository : IRepository<ScoreModel>
    {
        private const string MaxScoreValueFieldName = "MaxScoreValue";
        
        public void AddOrUpdate(ScoreModel item)
        {
            PlayerPrefs.SetInt(MaxScoreValueFieldName, item.Value);
        }

        public ScoreModel Get()
        {
            var value = PlayerPrefs.GetInt(MaxScoreValueFieldName, 0);
            return new ScoreModel(value);
        }
    }
}