using Abstracts.Data;
using Abstracts.Initialization;
using Composite.Base;
using Systems.Score;
using Systems.Score.Models;
using UnityEngine;

namespace Composite.Initialization
{
    public class ScoreSystemInitializer : CompositeInitializer
    {
        [SerializeField] private ScoreSystem _scoreSystem;
        [SerializeField] private InitializerBase<IRepository<ScoreModel>> _scoreRepositoryInitializer;
        public override void Initialize()
        {
            var repository = _scoreRepositoryInitializer.Create();
            _scoreSystem.Initialize(repository);
        }
    }
}