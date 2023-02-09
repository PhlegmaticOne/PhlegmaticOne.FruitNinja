using Concrete.Commands.ModelCommands.Base;
using Entities.Base;
using Systems.Score;

namespace Concrete.Commands.ModelCommands
{
    public class AddScoreCommand : ICuttableBlockOnDestroyCommand
    {
        private readonly ScoreSystem _scoreSystem;
        public AddScoreCommand(ScoreSystem scoreSystem) => _scoreSystem = scoreSystem;

        public void OnDestroy(CuttableBlock entity) => _scoreSystem.AddScorePoints(entity.BlockInfo.ScoreForSlicing);
    }
}