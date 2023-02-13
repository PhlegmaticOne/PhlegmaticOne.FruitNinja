using Abstracts.Initialization;
using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.ViewCommands;
using Helpers;
using Systems.Combos;
using Systems.Score;
using UnityEngine;

namespace Initialization.BlockCommands
{
    public class ScoreHandlingCommandInitializer : InitializerBase<ICuttableBlockOnDestroyCommand>
    {
        [SerializeField] private ComboSystem _comboSystem;
        [SerializeField] private ScoreSystem _scoreSystem;
        [SerializeField] private TemporaryTextMeshPro _temporaryTextMeshPro;
        [SerializeField] private Transform _textTransform;
        public override ICuttableBlockOnDestroyCommand Create() => 
            new ScoreHandlingViewCommand(new ComboScoreHandlingPolicy(), _comboSystem,
                _scoreSystem, _temporaryTextMeshPro, _textTransform);
    }
}