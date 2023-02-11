using Concrete.Commands.ViewCommands.Base;
using Concrete.Commands.ViewCommands.Models;
using Entities.Base;
using Systems.Score;

namespace Concrete.Commands.ViewCommands
{
    public class AddScoreCommand : ICuttableBlockOnDestroyViewCommand
    {
        private readonly ScoreSystem _scoreSystem;
        public AddScoreCommand(ScoreSystem scoreSystem) => _scoreSystem = scoreSystem;

        public void OnDestroy(CuttableBlock entity, BlockDestroyContext destroyContext)
        {
            _scoreSystem.AddScorePoints(entity.BlockInfo.ScoreForSlicing);
        }
    }
}