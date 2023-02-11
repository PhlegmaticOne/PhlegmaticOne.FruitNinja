using Abstracts.Initialization;
using Concrete.Commands.ViewCommands;
using Concrete.Commands.ViewCommands.Base;
using Systems.Score;
using UnityEngine;

namespace Initialization.ViewCommands
{
    public class AddScoreCommandInitializer : InitializerBase<ICuttableBlockOnDestroyViewCommand>
    {
        [SerializeField] private ScoreSystem _scoreSystem;
        public override ICuttableBlockOnDestroyViewCommand Create() => new AddScoreCommand(_scoreSystem);
    }
}