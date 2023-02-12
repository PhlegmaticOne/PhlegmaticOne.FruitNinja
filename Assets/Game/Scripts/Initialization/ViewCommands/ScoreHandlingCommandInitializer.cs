using Abstracts.Initialization;
using Concrete.Commands.ViewCommands;
using Concrete.Commands.ViewCommands.Base;
using Systems.Combos;
using Systems.Score;
using UnityEngine;

namespace Initialization.ViewCommands
{
    public class ScoreHandlingCommandInitializer : InitializerBase<ICuttableBlockOnDestroyViewCommand>
    {
        [SerializeField] private ComboSystem _comboSystem;
        [SerializeField] private ScoreSystem _scoreSystem;
        [SerializeField] private TemporaryScreenScoreView _temporaryScreenScoreView;
        [SerializeField] private Transform _textTransform;
        public override ICuttableBlockOnDestroyViewCommand Create() => 
            new ScoreHandlingViewCommand(new ComboScoreHandlingPolicy(), _comboSystem,
                _scoreSystem, _temporaryScreenScoreView, _textTransform);
    }
}