using Abstracts.Data;
using Abstracts.Initialization;
using Game.Scripts.Concrete.Data;
using Systems.Score.Models;

namespace Initialization.Repositories
{
    public class RepositoryInitializer : InitializerBase<IRepository<ScoreModel>>
    {
        public override IRepository<ScoreModel> Create() => new InMemoryMaxScoreRepository();
    }
}