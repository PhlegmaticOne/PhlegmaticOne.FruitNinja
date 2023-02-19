using Abstracts.Data;
using Abstracts.Initialization;
using Concrete.Data;
using Systems.Score.Models;

namespace Initialization.Repositories
{
    public class RepositoryInitializer : InitializerBase<IRepository<ScoreModel>>
    {
        public override IRepository<ScoreModel> Create() => new PrefsMaxScoreRepository();
    }
}