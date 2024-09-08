using Composite.Base;
using Concrete.Commands.ButtonCommands;
using Configurations.Systems;
using Initialization.Stages;
using Scenes;
using Systems.Blocks;
using Systems.Health;
using Systems.Losing;
using Systems.Score;
using UnityEngine;

namespace Composite.Initialization
{
    public class LosingSystemInitializer : CompositeInitializer
    {
        [SerializeField] private LosingSystem _losingSystem;

        [SerializeField] private int _startSceneIndex;
        [SerializeField] private LosingSystemConfiguration _losingSystemConfiguration;
        [SerializeField] private LosePopup _losePopup;
        [SerializeField] private HealthSystem _healthSystem;
        [SerializeField] private StateCheckingBlocksSystem _stateCheckingBlocksSystem;
        [SerializeField] private ScoreSystem _scoreSystem;
        [SerializeField] private SceneTransition _sceneTransition;
        [SerializeField] private StageablesAccessor _stageablesAccessor;
        public override void Initialize()
        {
            var stageables = _stageablesAccessor.GetStageables();
            
            _losingSystem.Initialize(_losingSystemConfiguration,
                _losePopup,
                _healthSystem,
                _stateCheckingBlocksSystem,
                _scoreSystem,
                new DisableCommand(stageables),
                new RestartCommand(stageables),
                new TransitToSceneCommand(_startSceneIndex, _sceneTransition));
        }
    }
}