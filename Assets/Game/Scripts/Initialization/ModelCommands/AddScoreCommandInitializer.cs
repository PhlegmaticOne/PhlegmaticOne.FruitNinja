using Abstracts.Initialization;
using Concrete.Commands.ModelCommands;
using Concrete.Commands.ModelCommands.Base;
using Systems.Score;
using UnityEngine;

namespace Initialization.ViewCommands
{
    public class AddScoreCommandInitializer : InitializerBase<ICuttableBlockOnDestroyCommand>
    {
        [SerializeField] private ScoreSystem _scoreSystem;
        public override ICuttableBlockOnDestroyCommand Create() => new AddScoreCommand(_scoreSystem);
    }
}